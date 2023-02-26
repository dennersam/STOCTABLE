import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ProdutoService } from '../services/produto.service';
import { Produto } from './../model/produto';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.scss'],
})
export class ProdutoFormComponent implements OnInit {
  produtoForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService
  ) {}

  ngOnInit(): void {
    this.produtoForm = this.fb.group({
      descricao: [null, Validators.required],
      fabricante: [null],
      unidade: [null],
      setor: [null],
      fornecedor: [null],
      precoCusto: [null],
      precoVenda: [null],
      precoMedio: [null],
      margemLucro: [null],
      quantidade: [null, Validators.required],
      qtMinima: [null, Validators.required],
      AlicotaICMS: [null],
      baseCalcICMS: [null],
      pesoBruto: [null],
      pesoLiquido: [null],
      codigoInterno: [null],
      observacao: [null],
    });
  }

  adicionarProduto() {
    const produto: Produto = this.produtoForm.value;

    console.log(produto);

    this.produtoService.salvarProduto(produto).subscribe((result) => {
      alert('Produto cadastrado!');
    });
  }

  removerProduto() {}
}
