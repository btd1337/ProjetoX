import { Equipamento } from './Equipamento';

export class Alarme {
	id: number;
	equipamento: Equipamento;
	dataAlarme: Date;
	descricao: string;
}
