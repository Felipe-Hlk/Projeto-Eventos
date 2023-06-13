import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(/*{providedIn: 'root'}*/)

export class EventoService {

  baseURL = ' https://localhost:5001/api/Eventos '

  constructor(private http: HttpClient) { }

 public getEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
/* referencia da URL relacionada ao '[HttpGet]' inserido na Controller no back-end */
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
/* referencia da URL relacionada ao '[HttpGet("{tema}/tema")]' inserido na Controller no back-end */
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
/* referencia da URL relacionada ao '[HttpGet("{id}")]' inserido na Controller no back-end */

  }
}







