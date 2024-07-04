import { Component } from '@angular/core';
import { Measure } from '../measure';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'; //dodane
import { FormControl, FormGroup, Validators, ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';
import { OperationResult } from '../operation-result';
import { NgbDateNativeAdapter, NgbDateStruct, NgbDateAdapter, NgbModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-measures-and-history',
  templateUrl: './measures-and-history.component.html',
  styleUrl: './measures-and-history.component.css'
})


export class MeasuresAndHistoryComponent {

  readonly APIUrl="https://localhost:5001/api/measure";
  measures: Measure[] = [];

  measureForm: FormGroup;
  isLoaded: boolean = false;
  operationResult: OperationResult | null;
  isFormVisible: boolean = false;
  editableMode = false;
  editableMeasure: Measure;
  actualMeasure: Measure;

  constructor(private http:HttpClient, private formBuilder: FormBuilder, private adapter: NgbDateNativeAdapter){
  }

  get formId(): FormControl {return this.measureForm.get("id") as FormControl};
  get formDate(): FormControl {return this.measureForm.get("measureDate") as FormControl};
  get formWeight(): FormControl {return this.measureForm.get("weight") as FormControl};
  get formWaist(): FormControl {return this.measureForm.get("waist") as FormControl};
  get formHips(): FormControl {return this.measureForm.get("hips") as FormControl};
  get formThigh(): FormControl {return this.measureForm.get("thigh") as FormControl};
  get formArm(): FormControl {return this.measureForm.get("arm") as FormControl};
  get formChest(): FormControl {return this.measureForm.get("chest") as FormControl};


  ngOnInit(){
    this.getMeasures();
    this.measureForm = this.formBuilder.group({
      id: Number,
      measureDate: new FormControl('', {validators: [Validators.required]}),
      weight: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]}),
      waist: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]}),
      hips: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]}),
      thigh: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]}),
      arm: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]}),
      chest: new FormControl('', {validators: [Validators.min(10), Validators.max(500), Validators.required]})
    });

    this.isLoaded = true;
  }

  toNgbDate(date: Date): NgbDateStruct | null{
    if(date == null)
      return null;
    date = new Date(date);
    return this.adapter.fromModel(date);
  } 

  getMeasures(){
    this.http.get<Measure[]>(this.APIUrl+"/GetAll").subscribe(data =>{
      this.measures=data;
    })
  }

  add(){
    this.measureForm.reset();
    this.measureForm.enable();
    this.formDate.setValue(this.toNgbDate(new Date()));
    this.operationResult = null;
    this.isFormVisible = true;
    this.editableMode = false;
  }
  cancel(){
    this.measureForm.reset();
    this.operationResult = null;
    this.isFormVisible = false;
  }

  edit(measure: Measure){
    this.measureForm.reset();
    this.editableMeasure = measure;
    this.isFormVisible = true;
    this.editableMode = true;
    this.operationResult = null;
    this.fillForm(measure);
  }
  delete(id: Number){

    this.http.delete<OperationResult>(this.APIUrl+"/Delete/"+id).subscribe( result => {
      this.operationResult = result;
      if(result.isSuccess){
        this.getMeasures(); //aktaulizacja tabelki historii
      }
        /*next: data => {
            this.operationResult = new OperationResult;
            this.operationResult.isSuccess = true;
            this.getMeasures();
        },
        error: error => {
          this.operationResult = new OperationResult;
          this.operationResult.isSuccess = false;
          this.operationResult.errors.push(error.messages);
        }*/
      });

  } 

  fillForm(measure: Measure){
    this.formId.setValue(measure.id);
    this.formDate.setValue(this.toNgbDate(measure.measureDate));    
    this.formDate.disable();
    this.formWeight.setValue(measure.weight);
    this.formWaist.setValue(measure.waist);
    this.formHips.setValue(measure.hips);
    this.formThigh.setValue(measure.thigh);
    this.formArm.setValue(measure.arm);
    this.formChest.setValue(measure.chest);
  }

  insert(){
    if(this.measureForm.invalid){ //walidacje formularza (u gory sa) np. required itp. WSTEPNE SITO PRZED BACKENDZIE
      this.measureForm.markAllAsTouched(); //powoduje, ze wszystkie pola sa jakby dotkniete przez uzytkownika, 
                                           //co uruchamia walidacje dla tych pol 
                                          //( w tym wypisuje komikaty, ok. linii 15-16 html)
      return;
    }
    this.http.post<OperationResult>(this.APIUrl+"/CreateMeasure", this.measureForm.getRawValue()).subscribe(result =>{
    this.operationResult = result;
    if(result.isSuccess){
      //this.operationResult.userMessage = "User message: Insert good" //wywalam userMessaage stad,
                                                                       // bo juz na backendzie jest userMessage
      this.getMeasures();
      this.isFormVisible = false;
    }
    })
  }

  save(){
    if(this.measureForm.invalid){
      this.measureForm.markAllAsTouched(); 
      return;
    }
    this.http.put<OperationResult>(this.APIUrl+"/Update", this.measureForm.getRawValue()).subscribe(result =>{
      this.operationResult = result;
      if(result.isSuccess){
        this.getMeasures(); //aktaulizacja tabelki historii
        this.isFormVisible = false;
      }
      })

  }

}
