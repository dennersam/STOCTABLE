import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RecuperarSenhaComponent } from './recuperar-senha/recuperar-senha.component';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoginComponent,
    RecuperarSenhaComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    ReactiveFormsModule
  ]
})
export class UsuarioModule { }
