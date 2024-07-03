import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { MenuComponent } from './menu/menu.component';
import { AboutComponent } from './about/about.component';


@NgModule({
  declarations: [
    MenuComponent,
    AboutComponent
  ],
  imports: [
    CommonModule,
    MainRoutingModule
  ]
})
export class MainModule { }
