import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Dto/employeeDto';
import { String } from 'typescript-string-operations';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient: HttpClient) { }

  getEmployeeById(id: number): Observable<Employee[]>  {
    return this.httpClient.get<Employee[]>(String.Format(environment.ApiEmployeeById, id));
  }

  getEmployees(): Observable<Employee[]>  {
    return this.httpClient.get<Employee[]>(String.Format(environment.ApiEmployees));
  }
}
