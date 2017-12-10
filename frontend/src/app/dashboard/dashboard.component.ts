import { NgStyle } from '@angular/common';
import { Maquina } from './../model/maquina';
import { Observable } from 'rxjs/Observable';
import { Equipamento } from './../model/equipamento';
import { Component, OnInit, OnDestroy } from '@angular/core';
import * as Chartist from 'chartist';
import { EquipamentoService } from 'app/services/equipamento.service';
import { MaquinasService } from 'app/services/maquinas.service';
import { Subscription } from 'rxjs/Subscription';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();

  data: any;
  interval: any;

  private ultimoUpdate: Date;
  private equipamentos: Equipamento[];
  private maquinas: Maquina[];

  constructor(
    private equipamentoService: EquipamentoService,
    private maquinaService: MaquinasService) {
  }

  getEquipamentos(): void {
    this.equipamentoService.getEquipamentos()
      .subscribe(
      equipamentos => this.equipamentos = equipamentos,
      error => { });
  }

  getMaquinas(): void {
    this.maquinaService.getMaquinas()
      .subscribe(
      maquinas => this.maquinas = maquinas,
      error => { });
  }

  defineCor(cor: string): string {
    if (cor === 'green') {
      return '#4aa74f';
    } else if (cor === 'orange') {
      return '#fc8f04';
    } else if (cor === 'red') {
      return '#f54336';
    } else {
      return '#1E88E5';
    }
  }

  defineBadge(info: string, taxa: number): string {

    if (info === 'Manutenção') {
      return 'av_timer';
    } else if (info === 'Parada' || (taxa > 15)) {
      return 'warning';
    } else if (info === 'Mensagem Recebida') {
      return 'announcement';
    } else if (info === '') {
      return 'assignment_turned_in';
    } else {
      return 'autorenew';
    }
  }

  getMessage(info: string): string {
    if (info === '') {
      return '';
    } else if (info === 'Manutenção') {
      //const tempo = this.getTempoAleatorio();
      return ' Em manutenção há 3h';
    } else if (info === 'Parada') {
      //const tempo = this.getTempoAleatorio();
      return ' PARADO HÁ 47 min';
    } else if (info === 'Mensagem Recebida') {
      return ' Mensagem Recebida';
    } else {
      return ' ';
    }
  }

  getTempoAleatorio() {
    const max = 120;
    const min = 1;
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  startAnimationForLineChart(chart) {
    let seq: any, delays: any, durations: any;
    seq = 0;
    delays = 80;
    durations = 500;

    chart.on('draw', function (data) {
      if (data.type === 'line' || data.type === 'area') {
        data.element.animate({
          d: {
            begin: 600,
            dur: 700,
            from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
            to: data.path.clone().stringify(),
            easing: Chartist.Svg.Easing.easeOutQuint
          }
        });
      } else if (data.type === 'point') {
        seq++;
        data.element.animate({
          opacity: {
            begin: seq * delays,
            dur: durations,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq = 0;
  };
  startAnimationForBarChart(chart) {
    let seq2: any, delays2: any, durations2: any;

    seq2 = 0;
    delays2 = 80;
    durations2 = 500;
    chart.on('draw', function (data) {
      if (data.type === 'bar') {
        seq2++;
        data.element.animate({
          opacity: {
            begin: seq2 * delays2,
            dur: durations2,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq2 = 0;
  };
  ngOnInit() {
    /* ----------==========     Daily Sales Chart initialization For Documentation    ==========---------- */

    this.refreshData();
    this.interval = setInterval(() => {
      this.refreshData();
      this.ultimoUpdate = new Date();
    }, 10000);

    const dataDailySalesChart: any = {
      labels: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
      series: [
        [4, 18, 26, 20, 24, 21, 7]
      ]
    };

    const optionsDailySalesChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 0
      }),
      low: 0,
      high: 50, // Projeto X: we recommend you to set the high sa the biggest value + something for a better look
      chartPadding: { top: 0, right: 0, bottom: 0, left: 0 },
    }

    var dailySalesChart = new Chartist.Line('#dailySalesChart', dataDailySalesChart, optionsDailySalesChart);

    this.startAnimationForLineChart(dailySalesChart);


    /* ----------==========     Completed Tasks Chart initialization    ==========---------- */

    const dataCompletedTasksChart: any = {
      labels: ['9h', '10h', '11h', '12h', '13h', '14h', '15h', '16h'],
      series: [
        [0, 45, 17, 0, 0, 35, 10, 0]
      ]
    };

    const optionsCompletedTasksChart: any = {
      lineSmooth: Chartist.Interpolation.cardinal({
        tension: 0
      }),
      low: 0,
      high: 100, // Projeto X: we recommend you to set the high sa the biggest value + something for a better look
      chartPadding: { top: 0, right: 0, bottom: 0, left: 0 }
    }

    var completedTasksChart = new Chartist.Line('#completedTasksChart', dataCompletedTasksChart, optionsCompletedTasksChart);

    // start animation for the Completed Tasks Chart - Line Chart
    this.startAnimationForLineChart(completedTasksChart);



    /* ----------==========     Emails Subscription Chart initialization    ==========---------- */

    var dataEmailsSubscriptionChart = {
      labels: ['M1', 'M2', 'M3', 'M4', 'M5', 'M6', 'M7', 'M8'],
      series: [
        [542, 443, 320, 780, 553, 453, 326, 434]

      ]
    };
    var optionsEmailsSubscriptionChart = {
      axisX: {
        showGrid: false
      },
      low: 0,
      high: 1000,
      chartPadding: { top: 0, right: 5, bottom: 0, left: 0 }
    };
    var responsiveOptions: any[] = [
      ['screen and (max-width: 640px)', {
        seriesBarDistance: 5,
        axisX: {
          labelInterpolationFnc: function (value) {
            return value[0];
          }
        }
      }]
    ];
    var emailsSubscriptionChart = new Chartist.Bar('#emailsSubscriptionChart', dataEmailsSubscriptionChart, optionsEmailsSubscriptionChart, responsiveOptions);

    //start animation for the Emails Subscription Chart
    this.startAnimationForBarChart(emailsSubscriptionChart);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    clearInterval(this.interval);
  }

  refreshData() {
    this.getMaquinas();
}
}


