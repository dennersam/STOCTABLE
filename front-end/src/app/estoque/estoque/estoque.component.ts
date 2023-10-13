import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';
import { Component, Input, OnInit, Output } from '@angular/core';
import { MatLegacyDialog as MatDialog } from '@angular/material/legacy-dialog';
import { MatLegacyTableDataSource as MatTableDataSource } from '@angular/material/legacy-table';

import { Produto } from '../model/produto';
import { ProdutoFormComponent } from '../produto-form/produto-form.component';
import { ProdutoService } from '../services/produto.service';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.scss'],
})
export class EstoqueComponent implements OnInit {
  @Input() closeDialog() {
    this.dialog.closeAll();
  }

  produtos: Produto[] = [];

  dataSource = new MatTableDataSource<any>();
  selection = new SelectionModel<Produto>(true, []);
  pesquisa!: FormGroup;
  text: string = '';

  constructor(
    public dialog: MatDialog,
    private produtoService: ProdutoService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.showProdutos();

    this.pesquisa = this.fb.group({
      campoPesquisa: [''],
    });

    this.pesquisa
      .get('campoPesquisa')
      ?.valueChanges.subscribe((valor: string) => {
        this.text = valor;
        this.resetPesquisa();
      });
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Produto): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${
      row.id + 1
    }`;
  }

  showProdutos() {
    this.produtoService
      .listarProdutos()
      .subscribe((produto: Produto[]) => (this.produtos = produto));
  }

  resetPesquisa(): void {
    this.produtos = [];
    this.showProdutos();
  }

  addProduto(): void {
    const dialogRef = this.dialog.open(ProdutoFormComponent, {
      height: '90%',
      width: '80%',
    });
  }

  delProduto(): void {}
}
