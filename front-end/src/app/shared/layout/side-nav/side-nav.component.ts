import { Component, OnInit } from '@angular/core';
import { navBarData } from './navBarData';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {

  collapsed = true;
  navData = navBarData;
  constructor() { }

  ngOnInit(): void {
  }

  toggleCollapse(){
    this.collapsed = !this.collapsed;
  }

}
