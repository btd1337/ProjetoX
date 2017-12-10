import { MaquinasService } from './services/maquinas.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { ReporteComponent } from './reporte/reporte.component';
import { TableListComponent } from './table-list/table-list.component';
import { IconsComponent } from './icons/icons.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { EquipamentoService } from 'app/services/equipamento.service';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ReporteComponent,
    TableListComponent,
    IconsComponent,
    NotificationsComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ComponentsModule,
RouterModule,
    AppRoutingModule
  ],
  providers: [
    EquipamentoService,
    MaquinasService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
