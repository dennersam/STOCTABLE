import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Produto } from './../model/produto';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private readonly URL: string = 'https://localhost:7098/api/Produto';

  //private tokenHeader = new HttpHeaders({'Authorization': `Bearer ${JSON.parse(localStorage.getItem('user') || '{}').token}`});

  constructor(private httpClient: HttpClient) { }

  listarProdutos(): Observable<Produto[]> {
    return this.httpClient.get<Produto[]>(this.URL);
  }

  listarProdutoPorId(id: number): Observable<Produto>{
    const apiURL = `${this.URL}/${id}`;
    return this.httpClient.get<Produto>(apiURL);
  }

  salvarProduto(produto: Produto): Observable<Produto>{
    return this.httpClient.post<Produto>(this.URL, produto)
  }

  apagarProduto(id: number): Observable<any>{
    const apiURL = `${this.URL}/${id}`;
    return this.httpClient.delete<number>(apiURL, httpOptions);
  }
}
