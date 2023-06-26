import { Produto } from './produto';

export interface Fornecedor {
  id: number;
  cnpj: string;
  inscricaoEstadual?: string;
  refBancarias?: string;
  produtoId: number;
  produto: Produto;
}
