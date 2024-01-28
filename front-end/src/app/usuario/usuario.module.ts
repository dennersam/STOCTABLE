import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RecuperarSenhaComponent } from './recuperar-senha/recuperar-senha.component';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ComponentsModule } from '../shared/components/components.module';
import { RegistroComponent } from './registro/registro.component';
import { AuthLayoutComponent } from '../shared/layout/auth-layout/auth-layout.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    LoginComponent,
    RecuperarSenhaComponent,
    RegistroComponent,
    AuthLayoutComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    ReactiveFormsModule,
    ComponentsModule,
    FormsModule
  ]
})
export class UsuarioModule { }
