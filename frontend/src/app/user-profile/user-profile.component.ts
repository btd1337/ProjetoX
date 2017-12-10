import { Component, OnInit } from '@angular/core';

import { EquipamentoService } from 'app/services/equipamento.service';
import { Equipamento } from 'app/model/Equipamento';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

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
