import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-aniversario-detalhe',
  templateUrl: './aniversario-detalhe.component.html',
  styleUrls: ['./aniversario-detalhe.component.scss']
})
export class AniversarioDetalheComponent implements OnInit {

  form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  get f(): any {
    return this.form.controls;
  }

  ngOnInit(): void {
    this.validation();
  }

 public validation(): void {
   this.form = this.fb.group({
    nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(150)]],
    dataAniversario: ['', Validators.required],
    telefone: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    imagemUrl: ['', Validators.required]
   });
 }

 public resetForm(): void {
  this.form.reset();
 }

}
