import { MatLegacyPaginatorModule as MatPaginatorModule } from '@angular/material/legacy-paginator';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatLegacyTableModule as MatTableModule } from '@angular/material/legacy-table';
import { MatLegacyCheckboxModule as MatCheckboxModule } from '@angular/material/legacy-checkbox';
import { MatLegacyButtonModule as MatButtonModule } from '@angular/material/legacy-button';
import { MatLegacyFormFieldModule as MatFormFieldModule } from '@angular/material/legacy-form-field';
import { MatLegacyDialogModule as MatDialogModule } from '@angular/material/legacy-dialog';
import { MatLegacyInputModule as MatInputModule } from '@angular/material/legacy-input';
import { MatIconModule } from '@angular/material/icon';
import { MatLegacySelectModule as MatSelectModule } from '@angular/material/legacy-select';
import { CurrencyPipe } from '@angular/common';


import { EstoqueRoutingModule } from './estoque-routing.module';
import { EstoqueComponent } from './estoque/estoque.component';
import { ProdutoFormComponent } from './produto-form/produto-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    EstoqueComponent,
    ProdutoFormComponent
  ],
  imports: [
    CommonModule,
    EstoqueRoutingModule,
    MatTableModule,
    MatCheckboxModule,
    MatButtonModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports:[],
  providers:[
    CurrencyPipe
  ]
})
export class EstoqueModule { }
