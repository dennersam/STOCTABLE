import { ContaService } from './../services/conta.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioLogin } from '../models/UsuarioLogin';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public authForm!: FormGroup;
  public usuarioLogin?: UsuarioLogin;


  constructor(private fb: FormBuilder,
              private contaService: ContaService,
              private router: Router,
              private toastr: ToastrService
              ) { }

  ngOnInit(): void {
    this.authForm = this.fb.group({
      userName: ['',[Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  userLogin(): void {
    this.usuarioLogin = this.authForm.value;
    this.contaService.login(this.authForm.value).subscribe(
      () => { this.router.navigateByUrl('dashboard');},
      (error: any) => {
        if(error.status == 401) {
          this.toastr.error('Usuário ou senha inválidos!', 'Erro!', {positionClass : 'toast-top-center' });

        } else if(error.status == 500){
          this.toastr.error('Houve um erro ao tentar entrar, tente novamente mais tarde! ', 'Erro interno');
        } else {
          this.toastr.success('Usuario logado com sucesso', 'Login OK!')
        }
      }
    )
  }

  registro(){
    this.router.navigate((['usuario/registro']));
  }

}
