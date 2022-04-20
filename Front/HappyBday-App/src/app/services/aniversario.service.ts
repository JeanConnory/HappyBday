import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aniversario } from '../models/Aniversario';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '@app/models/Pagination';

@Injectable(
  //  { providedIn: 'root' }
)
export class AniversarioService {
  baseURL = environment.apiURL + 'api/aniversarios';

  constructor(private http: HttpClient) { }

  public getAniversarios(page?: number, itemsPerPage?: number, term?: string): Observable<PaginatedResult<Aniversario[]>> {
    const paginatedResult: PaginatedResult<Aniversario[]> = new PaginatedResult<Aniversario[]>();

    let params = new HttpParams;

    if(page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    if(term != null && term != '')
      params = params.append('term', term);

    return this.http.get<Aniversario[]>(this.baseURL, {observe: 'response', params})
              .pipe(
                take(1),
                map((response) => {
                  paginatedResult.result = response.body;
                  if(response.headers.has('Pagination')) {
                    paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
                  }
                  return paginatedResult;
                })
              );
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
