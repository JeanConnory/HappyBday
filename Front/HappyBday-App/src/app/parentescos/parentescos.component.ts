import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parentescos',
  templateUrl: './parentescos.component.html',
  styleUrls: ['./parentescos.component.scss']
})
export class ParentescosComponent implements OnInit {

  public parentescos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getParentesco();
  }

  public getParentesco(): void {
    this.http.get('https://localhost:5001/api/parentescos').subscribe(
      response => this.parentescos = response,
      error => console.log(error)
    );
  }

}
