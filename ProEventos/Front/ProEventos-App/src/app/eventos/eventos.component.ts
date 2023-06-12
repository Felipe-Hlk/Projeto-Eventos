
import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  // isCollapsed = true;

  public eventos: any = []; // eventos declarada, que recebera a ligação através da interpolação no html

  public eventosFiltrados: any = [];

  exibirImagem:boolean = true;
  private _filtroLista: string = '';

  public get filtroLista():string {
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

 filtrarEventos(filtrarPor: string): any{
  filtrarPor = filtrarPor.toLowerCase();
  return this.eventos.filter(
    (evento: {
      local: any; tema: string;
}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
  )


 }



  constructor(private eventoService: EventoService) { } // HttpCliente inserido no constructor obs: variável de nome 'http' após 'private'

  ngOnInit(): void { //ngOnInit executa antes da requisição pro html
    this.geteventos();// devido a funão do ngOninit getEventos precisa ser inserido após ser declarado, caso contrário não aprecerá na aplicação
  }

  /* O objetivo de encapsular a lógica de programção do array eventos dentro da função geteventos()
    é separar a obtenção dos dados da lógica de inicialização do componente. Essa abordagem é útil
    quando você precisa buscar dados de forma assíncrona, como por meio de uma requisição HTTP,
    o que será feito nessa atividade, os dados dos eventos serão obtidos de um serviço backend
    através de uma requisição HTTP, a função geteventos() irá conter a chamada ao serviço e
    a manipulação da resposta para preencher o array eventos. Dessa forma, separar essa lógica
    em um método separado permite manter o código mais organizado e reutilizável. As informações em
    getEventos serão buscadas em um banco de dados, não sendo assim estáticas.
  */

  public geteventos(): void {
    this.eventoService.getEvento().subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log (error)
      );

  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem
  }


}

