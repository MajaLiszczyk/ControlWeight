import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MeasuresAndHistoryComponent } from './measures-and-history/measures-and-history.component';

const routes: Routes = [
  { path: 'measures-and-history', component: MeasuresAndHistoryComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeasuresAndHistoryRoutingModule { }
