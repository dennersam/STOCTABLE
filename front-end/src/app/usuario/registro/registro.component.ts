import { ContaService } from './../services/conta.service';
import { Usuario } from './../models/Usuario';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss'],
})
export class RegistroComponent {
  usuario = {} as Usuario;
  public registryForm!: FormGroup;

  constructor(private fb: FormBuilder,
              private router: Router,
              private contaService: ContaService,
              private toaster: ToastrService) {}

  ngOnInit(): void {
    this.registryForm = this.fb.group({
      primeiroNome: ['', [Validators.required, Validators.minLength(3)]],
      ultimoNome: ['', [Validators.minLength(3)]],
      userName: ['', [Validators.minLength(5)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  registrarUsuario():void {
    this.usuario = { ...this.registryForm.value };
    this.contaService.register(this.usuario).subscribe(
      () => { this.router.navigateByUrl('login'),
            this.toaster.success('O usuário ' + this.usuario.primeiroNome + ' foi cadastrado com sucesso!' , 'Cadastro bem-sucedido!!')},
      (error: any) => this.toaster.error(error.error)
    )
  }

  goToLogin(){
    this.router.navigate(['usuario/login']);
  }
}
