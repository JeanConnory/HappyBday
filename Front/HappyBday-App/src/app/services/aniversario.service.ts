import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aniversario } from '../models/Aniversario';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable(
  //  { providedIn: 'root' }
)
export class AniversarioService {
  baseURL = environment.apiURL + 'api/aniversarios';
  tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJqZWFuIiwibmJmIjoxNjQ5OTc0NzI3LCJleHAiOjE2NTAwNjExMjcsImlhdCI6MTY0OTk3NDcyN30.wZyIbi81nICCMFthIcpqBCHJfEa_uLvBxGpMXgEBTGWvx9mOQd6iD9eQVV9qLfLMgZUhHlqm8DPhozIDrVtBFA' });

  constructor(private http: HttpClient) { }

  public getAniversarios(): Observable<Aniversario[]> {
    return this.http.get<Aniversario[]>(this.baseURL, { headers: this.tokenHeader }).pipe(take(1));
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

  postUpload(aniversarioId: number, file: File): Observable<Aniversario> {
    const fileToUpload = file[0] as File;
    const formData = new FormData();
    formData.append('file', fileToUpload);

    return this.http.post<Aniversario>(`${this.baseURL}/upload-image/${aniversarioId}`, formData).pipe(take(1));
  }
}
