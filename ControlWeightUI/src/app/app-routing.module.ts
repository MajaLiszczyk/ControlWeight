import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'main/menu', pathMatch: 'full' },
  { path: 'measures-and-history', loadChildren: () => import('./measures-and-history/measures-and-history.module').then(m => m.MeasuresAndHistoryModule) }, 
  { path: 'main', loadChildren: () => import('./main/main.module').then(m => m.MainModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
