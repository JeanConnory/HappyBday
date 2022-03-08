import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Parentesco } from '@app/models/Parentesco';
import { ParentescoService } from '@app/services/parentesco.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parentesco-lista',
  templateUrl: './parentesco-lista.component.html',
  styleUrls: ['./parentesco-lista.component.scss']
})
export class ParentescoListaComponent implements OnInit {

  public parentescos: Parentesco[] = [];
  public parentescosFiltrados: Parentesco[] = [];
  private _filtroLista: string = '';
  public parentescoId = 0;
  modalRef?: BsModalRef;

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.parentescosFiltrados = this.filtroLista ? this.filtrarParentescos(this.filtroLista) : this.parentescos;
  }

  constructor(private parentescoService: ParentescoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit() {
    this.spinner.show();
    this.carregarParentescos();
  }

  filtrarParentescos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.parentescos.filter(
      (parentesco: any) => parentesco.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public carregarParentescos(): void {
    this.parentescoService.getParentescos().subscribe({
      next: (parentescos: Parentesco[]) => {
        this.parentescos = parentescos,
          this.parentescosFiltrados = this.parentescos
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os parentescos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(event: any, template: TemplateRef<any>, parentescoId: number): void {
    event.stopPropagation();
    this.parentescoId = parentescoId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.parentescoService.deleteParentesco(this.parentescoId).subscribe(
      (result: any) => {
        this.toastr.success('O Parentesco foi deletado com sucesso!', 'Deletado');
        this.carregarParentescos();
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(`Erro ao tentar deletar o parentesco ${this.parentescoId}`);
      }).add(() => this.spinner.hide());
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheParentesco(id: number): void {
    this.router.navigate([`parentescos/detalhe/${id}`]);
  }
}
