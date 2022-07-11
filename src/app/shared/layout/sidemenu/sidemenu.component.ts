import { Component, Input, OnInit } from '@angular/core';

import { navbarData } from './model/navbarData';


@Component({
  selector: 'app-sidemenu',
  templateUrl: './sidemenu.component.html',
  styleUrls: ['./sidemenu.component.scss']
})
export class SidemenuComponent implements OnInit {

  collapsed: boolean = false;

  opened: boolean = true;

  menuList = navbarData;

  constructor() { }

  ngOnInit(): void {
  }

  menuBehaivor(){
    this.opened = !this.opened;
  }

}
