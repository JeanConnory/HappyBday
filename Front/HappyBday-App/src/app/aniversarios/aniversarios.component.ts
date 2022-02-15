import { Component, OnInit } from '@angular/core';
import { Aniversario } from '../models/Aniversario';
import { AniversarioService } from '../services/aniversario.service';

@Component({
  selector: 'app-aniversarios',
  templateUrl: './aniversarios.component.html',
  styleUrls: ['./aniversarios.component.scss']
  //providers: [AniversarioService]
})
export class AniversariosComponent implements OnInit {

  public aniversarios: Aniversario[] = [];
  public aniversariosFiltrados: Aniversario[] = [];
  public larguraImg: number = 75;
  public margemImg: number = 2;
  public exibirImg: boolean = true;
  private filtroListado: string = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.aniversariosFiltrados = this.filtroLista ? this.filtrarAniversarios(this.filtroLista) : this.aniversarios;
  }

  public filtrarAniversarios(filtrarPor: string): Aniversario[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.aniversarios.filter(
      (niver: any) => niver.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
       niver.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private aniversarioService: AniversarioService) { }

  ngOnInit() {
    this.getAniversarios();
  }

  public alterarImagem(): void {
    this.exibirImg = !this.exibirImg;
  }

  public getAniversarios():void {
    this.aniversarioService.getAniversarios().subscribe({
      next: (eventos: Aniversario[]) => {
        this.aniversarios = eventos,
        this.aniversariosFiltrados = this.aniversarios
      },
      error: (error: any) => console.log(error)
    });
  }
}
