import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component';
import { AdminComponent } from './components/admin/admin.component';
import { AniversariosComponent } from './components/aniversarios/aniversarios.component';
import { ParentescosComponent } from './components/parentescos/parentescos.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { AniversarioDetalheComponent } from './components/aniversarios/aniversario-detalhe/aniversario-detalhe.component';
import { AniversarioListaComponent } from './components/aniversarios/aniversario-lista/aniversario-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ParentescoDetalheComponent } from './components/parentescos/parentesco-detalhe/parentesco-detalhe.component';
import { ParentescoListaComponent } from './components/parentescos/parentesco-lista/parentesco-lista.component';

import { AniversarioService } from './services/aniversario.service';
import { ParentescoService } from './services/parentesco.service';
import { AccountService } from './services/account.service';

import { JwtInterceptor } from './interceptor/jwt.interceptor';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { DashboardComponent } from './components/dashboard/dashboard.component';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    ParentescosComponent,
    AniversariosComponent,
    NavComponent,
    AdminComponent,
    PerfilComponent,
    DashboardComponent,
    TituloComponent,
    DateTimeFormatPipe,
    AniversarioDetalheComponent,
    AniversarioListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    ParentescoDetalheComponent,
    ParentescoListaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  providers: [
    AccountService,
    AniversarioService,
    ParentescoService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
