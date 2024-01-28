import { Component, OnInit, Input } from '@angular/core';
import { ContaService } from 'src/app/usuario/services/conta.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.scss']
})
export class BodyComponent implements OnInit {

  @Input() collapsed = false;
  @Input() screenWidth = 0;

  constructor(private contaService: ContaService) { }

  ngOnInit(): void {
  }

  bodyClass(){
    let body = '';
    if(this.contaService.usuarioEstaAutenticado()){
      return body = 'body-adjusts';
    }else{
      return body;
    }
  }

  getBodyClass(): string{
    let styleClass = '';
    if(this.collapsed && this.screenWidth > 768 ){
      styleClass = 'body-adjusts body-trimmed';
    } else if(this.collapsed && this.screenWidth <= 768 && this.screenWidth > 0){
      styleClass = 'body-adjusts body-md-screen'
    } else if(this.contaService.usuarioEstaAutenticado()){
      styleClass = 'body-adjusts'
    }
    return styleClass;
  };

}
