import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminComponent } from './components/admin/admin.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

import { AniversariosComponent } from './components/aniversarios/aniversarios.component';
import { AniversarioListaComponent } from './components/aniversarios/aniversario-lista/aniversario-lista.component';
import { AniversarioDetalheComponent } from './components/aniversarios/aniversario-detalhe/aniversario-detalhe.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';

import { ParentescosComponent } from './components/parentescos/parentescos.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      {path: 'registration', component: RegistrationComponent }
    ]
  },
  { path: 'user/perfil', component: PerfilComponent },
  { path: 'aniversarios', redirectTo: 'aniversarios/lista'},
  {
    path: 'aniversarios', component: AniversariosComponent,
    children: [
      { path: 'detalhe/:id', component: AniversarioDetalheComponent },
      { path: 'detalhe', component: AniversarioDetalheComponent },
      { path: 'lista', component: AniversarioListaComponent }
    ]
  },
  { path: 'parentescos', component: ParentescosComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
