import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aniversario } from '../models/Aniversario';
import { take } from 'rxjs/operators';

@Injectable(
  //  { providedIn: 'root' }
)
export class AniversarioService {
  baseURL = 'https://localhost:5001/api/aniversarios';

  constructor(private http: HttpClient) { }

  public getAniversarios(): Observable<Aniversario[]> {
    return this.http.get<Aniversario[]>(this.baseURL).pipe(take(1));
  }

  public getAniversariosByNome(nome: string): Observable<Aniversario[]> {
    return this.http.get<Aniversario[]>(`${this.baseURL}/${nome}/nome`).pipe(take(1));
  }

  public getAniversarioById(id: number): Observable<Aniversario> {
    return this.http.get<Aniversario>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(aniversario: Aniversario): Observable<Aniversario> {
    return this.http.post<Aniversario>(this.baseURL, aniversario).pipe(take(1));
  }

  public put(aniversario: Aniversario): Observable<Aniversario> {
    return this.http.put<Aniversario>(`${this.baseURL}/${aniversario.id}`, aniversario).pipe(take(1));
  }

  public deleteAniversario(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
