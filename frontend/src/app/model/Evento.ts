import { Equipamento } from './Equipamento';

export class Evento {
    id: number;
    equipamento: Equipamento;
    dataEvento: Date;
	pecasBoas: number;
	pecasRuins: number;
}
