export interface Produto {
  id: number;
  codigo: number;
  descricao: string;
  unidade: string;
  fornecedor: string;
  fabricante: string;
  setor: string;
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
  codigoInterno: string;

}
