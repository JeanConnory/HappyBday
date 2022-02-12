import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-aniversarios',
  templateUrl: './aniversarios.component.html',
  styleUrls: ['./aniversarios.component.scss']
})
export class AniversariosComponent implements OnInit {

  public aniversarios: any = [];
  public aniversariosFiltrados: any = [];
  larguraImg: number = 75;
  margemImg: number = 2;
  exibirImg: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.aniversariosFiltrados = this.filtroLista ? this.filtrarAniversarios(this.filtroLista) : this.aniversarios;
  }

  filtrarAniversarios(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.aniversarios.filter(
      (niver: any) => niver.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
       niver.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAniversarios();
  }

  alterarImagem() {
    this.exibirImg = !this.exibirImg;
  }

  public getAniversarios():void {
    this.http.get('https://localhost:5001/api/aniversarios').subscribe(
      response => {
        this.aniversarios = response,
        this.aniversariosFiltrados = this.aniversarios
      },
      error => console.log(error)
    );
  }
}
