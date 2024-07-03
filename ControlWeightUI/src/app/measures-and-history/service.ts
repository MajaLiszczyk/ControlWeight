import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Measure } from '..//measures-and-history/measure';
import { OperationResult } from "./operation-result";


@Injectable({
    providedIn: 'root'
})
export class Service{

    readonly APIUrl="https://localhost:5001/api/measure";
    constructor(private http: HttpClient){}

    getMeasures(): Observable<Measure[]>{
        return this.http.get<Measure[]>(`{this.APIUrl}/GetAll`);
    }


}


