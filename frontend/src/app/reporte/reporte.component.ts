import { Component, OnInit } from '@angular/core';

import { EquipamentoService } from 'app/services/equipamento.service';
import { Equipamento } from 'app/model/equipamento';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})
export class ReporteComponent implements OnInit {

  private equipamentos: Equipamento[];
  
  constructor(private equipamentoService: EquipamentoService) { }

  getEquipamentos(): void {
    this.equipamentoService.getEquipamentos()
      .subscribe(
      equipamentos => this.equipamentos = equipamentos,
      error => {});
  }

  ngOnInit() {
    /* ----------==========     Daily Sales Chart initialization For Documentation    ==========---------- */

    this.getEquipamentos();

  }

}
