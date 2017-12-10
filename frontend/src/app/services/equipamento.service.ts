import { Equipamento } from './../model/equipamento';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class EquipamentoService {

	data: any = null;

	private apiUrl = 'https://sebrae.gear.host/home/equipamento/';

	constructor(private http: Http) {
	}
	
	getEquipamentos(): Observable<Equipamento[]> {
		return this.http.get(this.apiUrl)
		.map(res => res.json());
	}
}
