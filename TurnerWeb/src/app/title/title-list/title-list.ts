import {Component, OnInit} from '@angular/core';
import {Title} from '../shared/title';
import {Observable} from 'rxjs/Observable';
import {ActivatedRoute} from '@angular/router';
import {Pipe, PipeTransform} from '@angular/core';
import {FilterArrayPipe} from '../shared/filter.pipe';

@Component({
  selector: 'title-list',
  styleUrls: ['./title-list.css'],
  templateUrl: './title-list.html',
  pipes:[FilterArrayPipe]
})
export class RepoList implements OnInit {
  id: number;
  movies: Observable<any>;

  constructor(public title: Title, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      if (this.id) {
        this.movies = this.title.getMovieDetail(this.id);
      }
      else{
        this.movies = this.title.getMovieList();
      }
    });
  }
}
