import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Usuario } from '../models/Usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formLogin!: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.formLogin = this.fb.group({
      login: ['',[Validators.required]],
      senha: ['', [Validators.required]]
    })
  }

  loginForm(usuario: Usuario){
    this.formLogin = new FormGroup({
      login: new FormControl(usuario.login),
      senha: new FormControl(usuario.senha)
    })
  }

}
