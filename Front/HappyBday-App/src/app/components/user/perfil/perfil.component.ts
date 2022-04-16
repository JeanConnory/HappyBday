import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { UserUpdate } from '@app/models/Identity/UserUpdate';
import { AccountService } from '@app/services/account.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  userUpdate = {} as UserUpdate;
  form!: FormGroup;

  constructor(private fb: FormBuilder, public accountService: AccountService,
              private router: Router, private toastr: ToastrService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.validation();
    this.carregarUsuario();
  }

  private carregarUsuario(): void {
    this.spinner.show();
    this.accountService.getUser().subscribe(
      (userRetorno: UserUpdate) => {
        console.log(userRetorno);
        this.userUpdate = userRetorno;
        this.form.patchValue(this.userUpdate);
        this.toastr.success('Usuário Carregado', 'successo');
      },
      (error) => {
        console.error(error);
        this.toastr.error('Usuário não carregado', 'Erro');
        this.router.navigate(['/dashboard']);
      },
      () => this.spinner.hide()
    )
  }

  private validation(): void {
    const formOption: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmePassword')
    };
    this.form = this.fb.group({
      userName: [''],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      funcao: ['NaoInformado', Validators.required],
      profissao: ['NaoInformado', Validators.required],
      phoneNumber: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4)]],
      confirmePassword: ['', Validators.required]
    }, formOption);
  }

  get f(): any {
    return this.form.controls;
  }

  onSubmit(): void {
    this.atualizarUsuario();
  }

  public atualizarUsuario() {
    this.userUpdate = { ... this.form.value }
    this.spinner.show();

    this.accountService.updateUser(this.userUpdate).subscribe(
      () => this.toastr.success('Usuário atualizado!', 'Sucesso'),
      (error) => {
        this.toastr.error(error.error);
        console.error(error);
      },
      () => this.spinner.hide()
    )
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
  }
}
