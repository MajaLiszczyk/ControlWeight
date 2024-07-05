import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxSpinnerModule} from "ngx-spinner";
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbDateAdapter, NgbDateNativeAdapter } from '@ng-bootstrap/ng-bootstrap';

import { MeasuresAndHistoryRoutingModule } from './measures-and-history-routing.module';
import { MeasuresAndHistoryComponent } from './measures-and-history/measures-and-history.component';


@NgModule({
  declarations: [
    MeasuresAndHistoryComponent],
  imports: [
    CommonModule,
    MeasuresAndHistoryRoutingModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    NgbModule,
  ],

  providers: [
    NgbDateNativeAdapter
  ],
})
export class MeasuresAndHistoryModule { }
