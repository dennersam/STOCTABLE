import { Produto } from "./produto";
import { Pessoa } from "./pessoa";

export interface Fabricante extends Pessoa {
  id: number;
  rg: string;
  ocupacao?: string;
  salario?: number;
  admissao: Date;
  produtoId: number;
  produto: Produto;

}
