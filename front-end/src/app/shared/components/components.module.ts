import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StBotaoComponent } from './st-botao/st-botao.component';
import { StInputComponent } from './st-input/st-input.component';
import { FormsModule } from '@angular/forms';
import { StTituloComponent } from './st-titulo/st-titulo.component';



@NgModule({
  declarations: [
    StBotaoComponent,
    StInputComponent,
    StTituloComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    StBotaoComponent,
    StInputComponent,
    StTituloComponent
  ]
})
export class ComponentsModule { }
