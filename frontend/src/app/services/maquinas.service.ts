import { Maquinas } from './../model/maquinas';
import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MaquinasService {

	data: any = null;

	private apiUrl = 'https://sebrae.gear.host/home/maquinas/';

	constructor(private http: Http) {
	}
	
	getMaquinas(): Observable<Maquinas[]> {
		return this.http.get(this.apiUrl)
		.map(res => res.json());
	}
}
