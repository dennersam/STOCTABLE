import { Component, OnInit } from '@angular/core';
import { MatSidenavContainer } from '@angular/material/sidenav';


@Component({
  selector: 'app-sidemenu',
  templateUrl: './sidemenu.component.html',
  styleUrls: ['./sidemenu.component.css']
})
export class SidemenuComponent implements OnInit {

  collapsed: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
