import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fabricante } from '../model/fabricante';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FabricanteService {

  private readonly URL: string = environment.apiURL + 'api/Fabricante';

  constructor(private httpClient: HttpClient) { }

  listarFabricantes(): Observable<Fabricante[]> {
    return this.httpClient.get<Fabricante[]>(this.URL);
  }
}
