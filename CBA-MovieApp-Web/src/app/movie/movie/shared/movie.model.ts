import { Cast } from "./cast.model";

export class Movie {
    id: number;
    title: string;
    yearReleased: string;
    casts: Cast[];

    constructor() {
        this.id = 0;
        this.title = '';
        this.yearReleased = '';
        this.casts = new Array<Cast>();
    }
}
