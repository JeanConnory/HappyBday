import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parentesco } from '@app/models/Parentesco';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable()
export class ParentescoService {

  baseURL = 'https://localhost:5001/api/parentescos';

  constructor(private http: HttpClient) { }

  public getParentescos(): Observable<Parentesco[]> {
    return this.http.get<Parentesco[]>(this.baseURL).pipe(take(1));
  }

  public getParentescosByDescricao(descricao: string): Observable<Parentesco[]> {
    return this.http.get<Parentesco[]>(`${this.baseURL}/${descricao}/descricao`).pipe(take(1));
  }

  public getParentescoById(id: number): Observable<Parentesco> {
    return this.http.get<Parentesco>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(parentesco: Parentesco): Observable<Parentesco> {
    return this.http.post<Parentesco>(this.baseURL, parentesco).pipe(take(1));
  }

  public put(parentesco: Parentesco): Observable<Parentesco> {
    return this.http.put<Parentesco>(`${this.baseURL}/${parentesco.id}`, parentesco).pipe(take(1));
  }

  public deleteParentesco(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }
}
