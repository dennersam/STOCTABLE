import { Categoria } from './categoria';
import { Fornecedor } from './fornecedor';
import { Fabricante } from './fabricante';
import { Unidade } from '../enum/Unidade';

export interface Produto {
  id: number;
  descricao: string;
  unidade: Unidade[];
  //unidade: string;
  //fornecedor: Fornecedor[];
  fabricanteId: number;
  fabricante: Fabricante;
  //categoria: Categoria[];
  precoCusto: number;
  precoVenda: number;
  margemLucro: number;
  custoMedio: number;
  quantidade: number;
  qtMinima: number;
  observacao: string;
  AlicotaICMS: number;
  baseCalcICMS: number;
  pesoBruto: number;
  pesoLiquido: number;

}
