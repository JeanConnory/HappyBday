import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aniversario } from '../models/Aniversario';

@Injectable(
  //  { providedIn: 'root' }
)
export class AniversarioService {
  baseURL = 'https://localhost:5001/api/aniversarios';

  constructor(private http: HttpClient) { }

  public getAniversarios(): Observable<Aniversario[]> {
    return this.http.get<Aniversario[]>(this.baseURL);
  }

  public getAniversariosByNome(nome: string): Observable<Aniversario[]> {
    return this.http.get<Aniversario[]>(`${this.baseURL}/${nome}/nome`);
  }

  public getAniversarioById(id: number): Observable<Aniversario> {
    return this.http.get<Aniversario>(`${this.baseURL}/${id}`);
  }

}
