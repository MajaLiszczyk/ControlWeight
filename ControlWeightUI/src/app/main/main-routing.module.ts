import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { AboutComponent } from './about/about.component';

const routes: Routes = [
  { path: 'menu', component: MenuComponent },
  { path: 'about', component: AboutComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
