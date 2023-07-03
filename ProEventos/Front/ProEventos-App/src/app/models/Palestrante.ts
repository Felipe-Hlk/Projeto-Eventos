import { Evento } from "./evento";
import { RedeSocial } from "./Rede-Social";

export interface Palestrante{

    id: number;
    nome: string;
    miniCurriculo: string;
    imagemURL: string;
    telefone: string;
    email: string;
    redesSociais: RedeSocial;
    palestrantesEventos: Evento;

}
