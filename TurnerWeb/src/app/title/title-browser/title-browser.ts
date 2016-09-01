import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '../shared/title';

@Component({
  selector: 'title-browser',
  templateUrl: './title-browser.html',
  styleUrls: ['./title-browser.css']
})
export class RepoBrowser {

  constructor(private router: Router, private title: Title) {
  }

  searchByName(name: string) {
    this.title.getMovieByName(name)
      .subscribe(({name}) => {
        console.log(name);
        this.router.navigate(['/title', name]);
      });
  }

}
