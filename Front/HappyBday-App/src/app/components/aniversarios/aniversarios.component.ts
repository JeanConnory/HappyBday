import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { AniversarioService } from '../../services/aniversario.service';
import { Aniversario } from '../../models/Aniversario';

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
              private spinner: NgxSpinnerService) { }

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
}
