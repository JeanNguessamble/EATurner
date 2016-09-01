import { Injectable } from '@angular/core';
import { Http, HTTP_PROVIDERS, Response, } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class Title {
  constructor(private http: Http) {}

  getMovieByName(name: string) {
    return this.makeApiCall(`title/search?value=${name}`);
  }
  getMovieList() {
    return this.makeApiCall(`title`);
  }
  getMovieDetail(id: number) {
    return this.makeApiCall(`title?value=${id}`);
  }

  private makeApiCall(path: string) {
    let url = `http://localhost:57492/api/${ path }`;

    return this.http.get(url)
      .map(res => (<Response>res).json());
  }
}
