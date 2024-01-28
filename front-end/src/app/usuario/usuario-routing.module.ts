import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RecuperarSenhaComponent } from './recuperar-senha/recuperar-senha.component';
import { RegistroComponent } from './registro/registro.component';
import { AuthLayoutComponent } from '../shared/layout/auth-layout/auth-layout.component';


const routes: Routes = [
  { path: '', component: AuthLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent},
      { path: 'recuperar-senha', component: RecuperarSenhaComponent },
      { path: 'registro', component: RegistroComponent }
    ] },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
