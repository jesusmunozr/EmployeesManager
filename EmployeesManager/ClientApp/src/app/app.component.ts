import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Employee } from './employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Employees Manager';
  employees: Employee[] = undefined;
  employeeId: number = undefined;

  constructor(private service: EmployeeService) {
  }

  getEmployeesClick() {
    if (!this.employeeId) {
      this.service.getEmployees()
        .subscribe(resp => this.employees = resp);
    } else {
      this.service.getEmployees(this.employeeId)
        .subscribe(resp => this.employees = resp);
    }
  }
}
