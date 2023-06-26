import { Produto } from "./produto";

export interface Fabricante {
  id: number;
  rg: string;
  ocupacao?: string;
  salario?: number;
  admissao: Date;
  produtoId: number;
  produto: Produto;

}
