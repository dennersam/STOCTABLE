import { Observable, map } from 'rxjs';
import { Component, Input, OnInit } from '@angular/core';
import { ContaService } from 'src/app/usuario/services/conta.service';
import { Usuario } from 'src/app/usuario/models/Usuario';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() collapsed = false;
  @Input() screenWidth = 0;
  userName:any;
  mostrarMenu: boolean = false;

  constructor(private contaService: ContaService) { }

  ngOnInit() {
   this.contaService.mostrarMenuEmitter.subscribe(
     mostrar => this.mostrarMenu = mostrar
    );

    if(localStorage.getItem('user') != null){
      this.userName = JSON.parse(localStorage.getItem('user') ?? "");
    }else{
      this.userName = { "primeiroNome": "User" }
    }
  }
  getHeadClass(): string{
    let styleClass = '';
    if(this.collapsed && this.screenWidth > 768){
      styleClass = 'head-trimmed';
    }else{
      styleClass = 'head-md-screen';
    }
    return styleClass;

  }

}
