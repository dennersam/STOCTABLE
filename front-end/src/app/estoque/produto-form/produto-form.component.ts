import { Fabricante } from './../model/fabricante';
import { FabricanteService } from './../services/fabricante.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
  unidades = ["Unidade", "Peça", "Caixa", "Quilo", "Litros", "Duzia", "Par", "Pacote"];
  selectedValue: any;
  fabricantes?: Fabricante[];

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService,
    private fabricanteServices: FabricanteService
  ) {}

  ngOnInit(): void {
    this.produtoForm = this.fb.group({
      descricao: [null, Validators.required],
      fabricante: [null],
      unidade: [this.unidades],
      fornecedor: [null],
      precoCusto: [null],
      precoVenda: [null],
      precoMedio: [null],
      margemLucro: [null],
      quantidade: [null, Validators.required],
      qtMinima: [null, Validators.required],
      alicotaICMS: [null],
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

  fecharDialogo(){

  }

  listegemDeFabricante(): any{
    //this.fabricanteServices.listarFabricantes();
    console.log(this.fabricanteServices.listarFabricantes());
    //.subscribe((fabricante: Fabricante[]) => (this.fabricantes = fabricante));

  }

  onOptionSelected(option: any) {
    console.log('Opção selecionada:', option);
    // Faça aqui o que desejar com a opção selecionada
    this.selectedValue = option;
  }
}
