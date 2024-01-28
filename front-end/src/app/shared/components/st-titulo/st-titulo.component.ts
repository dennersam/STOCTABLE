import { Component, Input } from '@angular/core';

@Component({
  selector: 'st-titulo',
  templateUrl: './st-titulo.component.html',
  styleUrls: ['./st-titulo.component.scss']
})
export class StTituloComponent {
  @Input() titulo?: string;
  @Input() descricao?: string;

}
