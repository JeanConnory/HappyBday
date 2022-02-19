import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Aniversario } from 'src/app/models/Aniversario';
import { AniversarioService } from 'src/app/services/aniversario.service';

@Component({
  selector: 'app-aniversario-lista',
  templateUrl: './aniversario-lista.component.html',
  styleUrls: ['./aniversario-lista.component.scss']
})
export class AniversarioListaComponent implements OnInit {

  public aniversarios: Aniversario[] = [];
  public aniversariosFiltrados: Aniversario[] = [];
  public larguraImg: number = 75;
  public margemImg: number = 2;
  public exibirImg: boolean = true;
  private filtroListado: string = '';

  modalRef?: BsModalRef;

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

  constructor(private aniversarioService: AniversarioService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router) { }

  ngOnInit() {
    this.spinner.show();
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
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os aniversários', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Aniversário foi deletado com sucesso!', 'Deletado');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheAniversario(id: number): void {
    this.router.navigate([`aniversarios/detalhe/${id}`]);
  }
}
