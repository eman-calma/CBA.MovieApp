import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Movie } from './movie.model';
import { Sort } from './sort.model';
@Injectable({
  providedIn: 'root'
})
export class MovieService {

  movieUrl =  `${environment.serverUrl}/api/movie`;
  constructor(private http: HttpClient) { }

  private getHttpHeaders() {
    return new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  search(sort: any): Observable<any> {
    const self = this;
    return this.http.post(`${this.movieUrl}/search`, sort, { headers: self.getHttpHeaders() })
    .pipe(
      map(data => <any>data));
  }

  getMovieById(id: number): Observable<any> {
    const self = this;
    return this.http.get(`${this.movieUrl}/`+ id, { headers: self.getHttpHeaders() })
    .pipe(
      map(data => <any>data));
  }

  create(movie : Movie): Observable<any> {
    const self = this;
    return this.http.post(`${this.movieUrl}`, movie, { headers: self.getHttpHeaders() })
    .pipe(
      map(data => <any>data));
  }

  update(movie : Movie): Observable<any> {
    const self = this;
    return this.http.put(`${this.movieUrl}`, movie, { headers: self.getHttpHeaders() })
    .pipe(
      map(data => <any>data));
  }
  
    
}