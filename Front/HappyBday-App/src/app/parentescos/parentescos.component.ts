import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parentescos',
  templateUrl: './parentescos.component.html',
  styleUrls: ['./parentescos.component.scss']
})
export class ParentescosComponent implements OnInit {

  public parentescos: any = [];
  public parentescosFiltrados: any = [];

  private _filtroLista: string = '';


  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.parentescosFiltrados =  this.filtroLista ? this.filtrarParentescos(this.filtroLista) : this.parentescos;
  }

  filtrarParentescos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.parentescos.filter(
      (parentesco: any) => parentesco.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getParentesco();
  }

  public getParentesco(): void {
    this.http.get('https://localhost:5001/api/parentescos').subscribe(
      response => {
        this.parentescos = response,
        this.parentescosFiltrados = this.parentescos
      },
      error => console.log(error)
    );
  }

}
