import { Component, OnInit } from '@angular/core';
import { Cast } from './shared/cast.model';
import { Movie } from './shared/movie.model';
import { MovieService } from './shared/movie.service';
import { Sort } from './shared/sort.model';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  movies: Movie[] = new Array<Movie>();
  movie: Movie = new Movie();
  sort: Sort = new Sort();
  cast: Cast = new Cast();
  isAscending: boolean = true;
  lastSortedColumn: string = "";
  castName: string = '';

  constructor(private movieService: MovieService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.prepareSortData();
    this.search();
  }

  keyPressNumbers(event: { which: any; keyCode: any; preventDefault: () => void; }) {
    var charCode = (event.which) ? event.which : event.keyCode;
    if ((charCode < 48 || charCode > 57)) {
      event.preventDefault();
      return false;
    } else {
      return true;
    }
  }
 

  prepareSortData(){
    this.sort.isAscending = true;
    this.sort.searchCriteria = '';
    this.sort.sortBy = '';
  }

  search() {
    const sortModel = { sortModel: this.sort };
    this.movieService.search(sortModel).subscribe(result => {
      this.movies = result.data;
    });
  }

  sortData(column: string){
      if (column == this.lastSortedColumn){
        this.isAscending = this.isAscending == true ? false : true;
      } else {
        this.isAscending = true;
      }
      this.sort.isAscending = this.isAscending;
      this.sort.sortBy = column;

      this.search();
      this.lastSortedColumn = column;
  }
  
  getById(id: number){
    this.movieService.getMovieById(id).subscribe(result => {
      this.movie = result.data;
    });
  }

  addCast(){
    if (this.castName == ""){
      this.toastr.warning('Cast name is required', 'Warning');
      return;
    }
    this.movie.casts.push({ name: this.castName});
    this.castName = '';
  }

  submit(){

    if (this.movie.title == "") {
      this.toastr.warning('Movie title is required', 'Warning');
      return;
    }
    if (!this.movie.yearReleased || this.movie.yearReleased.length < 4){
      this.toastr.warning('Invalid year', 'Warning');
      return;
    }
    if (this.movie.id == 0){
      this.create();
    } else {
      this.update(); 
    }
  }

  isValid() {
    return this.movie.casts.length == 0
    || this.movie.title == null || this.movie.title == ''
    || this.movie.yearReleased == null || (this.movie.yearReleased && this.movie.yearReleased.length < 4);
  }

  create(){
    this.movieService.create(this.movie).subscribe(result => { 
      this.movies.push(result.data);
      this.resetFields();
      this.toastr.success(result.message);
    });
  }

  update(){
    this.movieService.update(this.movie).subscribe(result => { 
      this.search();
      this.resetFields();
      this.toastr.success(result.message);
    });
  }

  resetFields(){
    this.movie.id = 0;
    this.movie.title = "";
    this.movie.yearReleased = '';
    this.cast.name = '';
    this.movie.casts = [];
  }

  deleteCast(value: string) {
    if (this.movie.casts == null || this.movie.casts.length == 0) {
      return;
    }
    const selectedIndex = this.movie.casts.findIndex(x => x.name == value);
    if (selectedIndex != -1) {
      this.movie.casts.splice(selectedIndex, 1);
    }
  }
}
