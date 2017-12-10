import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class EquipamentoService {

	data: any = null;

	private apiUrl = 'https://sebrae.gear.host/home/equipamento/';

	constructor(private _http: Http) {
	}
	
	private findAll() {
		return this._http.get(this.apiUrl)
					.map((res: Response) => res.json())
					 .subscribe(data => {
							this.data = data;
							console.log(this.data);
					});
	}
}
