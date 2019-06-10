import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Employee } from "./employee";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.url = baseUrl;
  }

  getEmployees(employeeId?: number) {
    if (employeeId) {
      return this.http.get<Employee[]>(this.url + `api/employees/${employeeId}`)
    } else {
      return this.http.get<Employee[]>(this.url + "api/employees");
    }
    
  }
}
