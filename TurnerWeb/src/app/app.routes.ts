import {Routes} from '@angular/router';
import {Home} from './home/home';
import {RepoBrowser} from './title/title-browser/title-browser';
import {RepoList} from './title/title-list/title-list';
import {RepoDetail} from './title/title-detail/title-detail';

export const rootRouterConfig: Routes = [
  {path: '', redirectTo: 'home', terminal: true},
  {path: 'home', component: Home},
  {path: 'title', component: RepoBrowser,
    children: [
      {path: '', component: RepoList},
      {path: ':org', component: RepoList,
        children: [
          {path: '', component: RepoDetail},
          {path: ':repo', component: RepoDetail}
        ]
      }]
  }
];

