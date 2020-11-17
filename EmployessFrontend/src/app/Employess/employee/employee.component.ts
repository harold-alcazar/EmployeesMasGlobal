import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/Dto/employeeDto';
import { EmployeeService } from 'src/app/services/employee.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employess: Employee[];
  employeeId: number;
  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }

  getEmployeeById(id: number) {
    this.employeeService.getEmployeeById(id).subscribe(employees =>
      this.employess = employees
    );
  }

  getAllEmployees() {
    this.employeeService.getEmployees().subscribe(employees =>
      this.employess = employees
    );
  }

  employeeSubmit(id: number) {
    if (id) {
      this.getEmployeeById(id);
      return;
    }

    this.getAllEmployees();
  }
}
