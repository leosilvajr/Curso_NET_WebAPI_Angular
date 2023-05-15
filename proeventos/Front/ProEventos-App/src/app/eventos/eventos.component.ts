import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {

  public eventos: any = [
  {
    Tema: 'Angular',
    Local: 'Tanabi'
  },
  {
    Tema: 'Java',
    Local: 'Cosmorama'
  },
  {
    Tema: 'Phyton',
    Local: 'Balsamo'
  },

]

}
