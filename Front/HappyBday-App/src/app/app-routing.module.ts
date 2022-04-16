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
import { ParentescoDetalheComponent } from './components/parentescos/parentesco-detalhe/parentesco-detalhe.component';
import { ParentescoListaComponent } from './components/parentescos/parentesco-lista/parentesco-lista.component';
import { AuthGuard } from './guard/auth.guard';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'user', redirectTo: 'user/perfil' },
      { path: 'user/perfil', component: PerfilComponent },
      { path: 'aniversarios', redirectTo: 'aniversarios/lista' },
      {
        path: 'aniversarios', component: AniversariosComponent,
        children:
          [
            { path: 'detalhe/:id', component: AniversarioDetalheComponent },
            { path: 'detalhe', component: AniversarioDetalheComponent },
            { path: 'lista', component: AniversarioListaComponent }
          ]
      },
      { path: 'parentescos', redirectTo: 'parentescos/lista' },
      {
        path: 'parentescos', component: ParentescosComponent,
        children:
          [
            { path: 'detalhe/:id', component: ParentescoDetalheComponent },
            { path: 'detalhe', component: ParentescoDetalheComponent },
            { path: 'lista', component: ParentescoListaComponent }
          ]
      },
      { path: 'admin', component: AdminComponent },
      { path: 'dashboard', component: DashboardComponent },
    ]
  },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent }
    ]
  },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
