import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable, take, map, ReplaySubject } from 'rxjs';
import { Usuario } from '../models/Usuario';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ContaService {

  private currentUserSource = new ReplaySubject<Usuario>(1);
  currentUser$ = this.currentUserSource.asObservable();

  private usuarioAutenticado: boolean = false;
  mostrarMenuEmitter = new EventEmitter<boolean>();

  baseUrl = environment.apiURL + 'api/conta/';

  constructor(private http: HttpClient) {}

  public login(model: any): Observable<void> {
    return this.http.post<Usuario>(this.baseUrl + 'login', model).pipe(
      take(1),
      map((response: Usuario) => {
        const usuario = response;
        if (usuario) {
          this.setCurrentUser(usuario);
          this.usuarioAutenticado = true;
          this.mostrarMenuEmitter.emit(true);
          //this.router.navigate(['dashboard']);
          this.usuarioEstaAutenticado();
        }
      })
    );
  }

  public register(model: any): Observable<void> {
    return this.http.post<Usuario>(this.baseUrl + 'registro', model).pipe(
      take(1),
      map((response: Usuario) => {
        const usuario = response;
        if (usuario) {
          this.setCurrentUser(usuario);
          //this.usuarioAutenticado = true;
          //this.mostrarMenuEmitter.emit(true);
          //this.router.navigate(['dashboard']);
          //this.usuarioEstaAutenticado();
        }
      })
    );
  }

  usuarioEstaAutenticado(){
    return this.usuarioAutenticado;
  }

  logout(): void {
    localStorage.removeItem('user');
    this.currentUserSource.next(null as any);
    this.currentUserSource.complete();
  }

  public setCurrentUser(user: Usuario): void{
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }
}
