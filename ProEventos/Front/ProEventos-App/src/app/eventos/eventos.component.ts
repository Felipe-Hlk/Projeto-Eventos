import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any =[
  {
    Tema: 'Angular',
    Local: 'Campo Grande-MS'
  },
  {
    Tema: 'React',
    Local: 'Belo Horizonte-MG'
  },
  {
    Tema: '.NET',
    Local: 'São Paulo-SP'
  },
  {
    Tema: 'Docker',
    Local: 'Florianópolis-SC'
  },
]

  constructor() { }

  ngOnInit(): void {
  }

}
