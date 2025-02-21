import { Routes } from '@angular/router';

import { PageNotFoundComponent } from './error-routing/not-found/not-found.component';
import { UncaughtErrorComponent } from './error-routing/error/uncaught-error.component';
import { ChildView1Component } from './child-view-1/child-view-1.component';
import { ChildViewComponent } from './child-view/child-view.component';
import { ChildView2Component } from './child-view-2/child-view-2.component';

export const routes: Routes = [
  { path: '', redirectTo: 'child-view-1', pathMatch: 'full' },
  { path: 'error', component: UncaughtErrorComponent },
  { path: 'child-view-1', component: ChildView1Component, data: { text: 'Child-View1' } },
  { path: 'child-view', component: ChildViewComponent, data: { text: 'Child-View' } },
  { path: 'child-view-2', component: ChildView2Component, data: { text: 'Child-View2' } },
  { path: '**', component: PageNotFoundComponent } // must always be last
];
