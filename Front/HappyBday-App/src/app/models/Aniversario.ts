import { Parentesco } from "./Parentesco";

export interface Aniversario {
  id: number;
  nome: string;
  dataAniversario?: Date;
  telefone: string;
  email: string;
  imagemUrl: string;
  parentescoId: number;
  parentesco: Parentesco;
}
