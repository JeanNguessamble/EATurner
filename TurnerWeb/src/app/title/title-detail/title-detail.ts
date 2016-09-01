import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs/Observable';
import {Title} from '../shared/title';

@Component({
  selector: 'title-detail',
  styleUrls: ['./title-detail.css'],
  templateUrl: './title-detail.html'
})
export class RepoDetail implements OnInit {
  private id:number;
  public repoDetail: Observable<any>;

  constructor(public title:Title, private router:Router, private route:ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      //this.org = this.router.routerState.parent(this.route).snapshot.params['org'];
      this.id = params['id'] || '';

      if (this.id) {
        this.repoDetail = this.title.getMovieDetail(this.id);
      }
    });
  }
}
