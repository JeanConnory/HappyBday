import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Aniversario } from '@app/models/Aniversario';
import { AniversarioService } from '@app/services/aniversario.service';
import { Parentesco } from '@app/models/Parentesco';
import { ParentescoService } from '@app/services/parentesco.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-aniversario-detalhe',
  templateUrl: './aniversario-detalhe.component.html',
  styleUrls: ['./aniversario-detalhe.component.scss']
})
export class AniversarioDetalheComponent implements OnInit {

  aniversario = {} as Aniversario;
  aniversarioId!: number;
  form!: FormGroup;
  estadoSalvar = 'post';
  parentescos: Parentesco[] = [];
  imagemURL = 'assets/upload.png';
  file!: File;
  //parentescos: Observable<Parentesco[]>;

  get f(): any {
    return this.form.controls;
  }

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private activatedRouter: ActivatedRoute,
    private router: Router,
    private aniversarioService: AniversarioService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private parentescoService: ParentescoService) {
    this.localeService.use('pt-br');
  }

  ngOnInit(): void {
    this.carregarAniversario();
    this.validation();
    this.parentescoService.getParentescos().subscribe(dados => {
      this.parentescos = dados;
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched }
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(150)]],
      dataAniversario: ['', Validators.required],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imagemUrl: [''],
      parentescoId: ['', Validators.required]
    });
  }

  public carregarAniversario() {
    this.aniversarioId = +this.activatedRouter.snapshot.paramMap.get('id');
    if (this.aniversarioId != null && this.aniversarioId !== 0) {
      this.spinner.show();
      this.estadoSalvar = 'put';
      this.aniversarioService.getAniversarioById(this.aniversarioId).subscribe(
        (aniversario: Aniversario) => {
          this.aniversario = { ...aniversario };
          this.form.patchValue(this.aniversario);
          if(this.aniversario.imagemUrl !== '') {
            this.imagemURL = environment.apiURL + 'resources/images/' + this.aniversario.imagemUrl;
          }
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar aniversário!');
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
        this.aniversario = { ...this.form.value };
        this.aniversarioService.post(this.aniversario).subscribe(
          (aniversarioRetorno: Aniversario) => {
            this.toastr.success('Aniversário salvo com sucesso!', 'Sucesso');
            this.router.navigate([`aniversarios/detalhe/${aniversarioRetorno.id}`]);
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar aniversário', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
      else {
        this.aniversario = { id: this.aniversario.id, ...this.form.value };
        this.aniversarioService.put(this.aniversario).subscribe(
          (aniversarioRetorno: Aniversario) => {
            this.toastr.success('Aniversário salvo com sucesso!', 'Sucesso');
            this.router.navigate([`aniversarios/detalhe/${aniversarioRetorno.id}`]);
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar aniversário', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }


  onFileChange(ev: any) {
    const reader = new FileReader();
    reader.onload = (event: any) => this.imagemURL = event?.target.result;
    this.file = ev.target.files;
    reader.readAsDataURL(this.file[0]);

    this.uploadImagem()
  }

  uploadImagem(): void {
    this.spinner.show();
    this.aniversarioService.postUpload(this.aniversarioId, this.file).subscribe(
      () => {
        this.carregarAniversario();
        this.toastr.success('Imagem atualizada com sucesso', 'Sucesso!');
      },
      (error: any) => {
        this.toastr.error('Erro ao fazer upload de imagem', 'Erro!');
        console.error(error);
      }
    ).add(() => this.spinner.hide());
  }


}
  // public salvarAlteracaoRefatorado(): void {
  //   this.spinner.show();
  //   if (this.form.valid) {
  //     this.aniversario = (this.estadoSalvar === 'post')
  //                         ? {... this.form.value}
  //                         : {id: this.aniversario.id, ... this.form.value};

  //     this.aniversarioService[this.estadoSalvar](this.aniversario).subscribe(
  //       () => this.toastr.success('Aniversário salvo com sucesso!', 'Sucesso'),
  //       (error: any) => {
  //         console.error(error);
  //         this.spinner.hide();
  //         this.toastr.error('Erro ao salvar aniversário', 'Erro');
  //       },
  //       () => this.spinner.hide()
  //     );
  //   }
  // }
