import { ContaService } from 'src/app/usuario/services/conta.service';
import { Component } from '@angular/core';


interface SideNavToggle{
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'stoctable-frontend';

  isSideNavCollapsed = false;
  screenWidth = 0;

  currentUser?: string;

  constructor(private contaService: ContaService){
    this.currentUser = localStorage.getItem('user')?.toString();
  }

  onToggleSideNav(data: SideNavToggle):void{
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }
}
