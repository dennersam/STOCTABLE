import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'st-botao',
  templateUrl: './st-botao.component.html',
  styleUrls: ['./st-botao.component.scss']
})
export class StBotaoComponent implements OnInit {
  @Input() estilo: string = 'btn-primary';

  constructor() {}

  ngOnInit(): void {

  }

}
