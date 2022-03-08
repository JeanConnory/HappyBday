import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Parentesco } from '@app/models/Parentesco';
import { ParentescoService } from '@app/services/parentesco.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parentesco-detalhe',
  templateUrl: './parentesco-detalhe.component.html',
  styleUrls: ['./parentesco-detalhe.component.scss']
})
export class ParentescoDetalheComponent implements OnInit {

  parentesco = {} as Parentesco;
  form!: FormGroup;
  estadoSalvar = 'post';

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder,
              private parentescoService: ParentescoService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService,
              private router: ActivatedRoute) { }

  ngOnInit() {
    this.carregarParentesco();
    this.validation();
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched }
  }

  public validation(): void {
    this.form = this.fb.group({
      descricao: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]]
    });
  }

  public carregarParentesco() {
    const parentescoIdParam = this.router.snapshot.paramMap.get('id');
    if (parentescoIdParam != null) {
      this.spinner.show();
      this.estadoSalvar = 'put';
      this.parentescoService.getParentescoById(+parentescoIdParam).subscribe(
        (parentesco: Parentesco) => {
          this.parentesco = { ...parentesco };
          this.form.patchValue(this.parentesco);
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar parentesco!');
          console.log(error);
        },
        () => this.spinner.hide()
      );
    }
  }

  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {
      if (this.estadoSalvar === 'post') {
        this.parentesco = { ...this.form.value, dataCriado: new Date().toLocaleString() };
        this.parentescoService.post(this.parentesco).subscribe(
          () => this.toastr.success('Parentesco salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar parentesco', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
      else {
        this.parentesco = { id: this.parentesco.id, ...this.form.value };
        this.parentescoService.put(this.parentesco).subscribe(
          () => this.toastr.success('Parentesco salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar parentesco', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }
}
