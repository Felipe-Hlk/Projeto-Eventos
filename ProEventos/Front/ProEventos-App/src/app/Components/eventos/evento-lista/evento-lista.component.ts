import { Component, HostListener, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
  
  modalRef!: BsModalRef;
  public eventos: any = []; // Array para armazenar os eventos
  public eventosFiltrados: any = []; // Array para armazenar os eventos filtrados
  exibirImagem: boolean = true; // Variável para controlar a exibição da imagem
  private _filtroLista: string = ''; // Variável para armazenar o filtro de pesquisa

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    // Filtra os eventos com base no valor do filtroLista
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase()
    return this.eventos.filter(
      (evento: {
        local: any; tema: string;
}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private eventoService: EventoService, // Serviço para obter os eventos
    private modalService: BsModalService, // Serviço para abrir modais
    private toastr: ToastrService, // Serviço para exibir notificações de sucesso
    private spinner: NgxSpinnerService // Serviço para exibir e ocultar o spinner
  ) {}

  ngOnInit(): void {
    this.geteventos(); // Obtém os eventos ao inicializar o componente
    this.spinner.show(); // Exibe o spinner

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide(); // Oculta o spinner após 5 segundos
    }, 1000);
  }

  public geteventos(): void {
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response; // Preenche o array de eventos com a resposta da requisição
        this.eventosFiltrados = this.eventos; // Define os eventos filtrados como todos os eventos no início
      },
      error => console.log(error),

    );
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem; // Alterna a exibição da imagem
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' }); // Abre o modal com o template fornecido
  }

  confirm(): void {
    this.modalRef?.hide(); // Fecha o modal
    this.toastr.success('Evento Excluído com Sucesso!'); // Exibe uma notificação de sucesso
  }

  decline(): void {
    this.modalRef?.hide(); // Fecha o modal
  }

  isTelaPequena = false;

  @HostListener('window:resize', ['$event'])
  onResize(event: Event) {
    this.isTelaPequena = window.innerWidth <= 767.98; // Defina o tamanho máximo para considerar como "tela pequena"
  }
}
