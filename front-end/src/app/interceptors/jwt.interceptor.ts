import { ContaService } from './../usuario/services/conta.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { Usuario } from '../usuario/models/Usuario';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private contaService: ContaService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser = {} as Usuario;
    this.contaService.currentUser$.pipe(take(1)).subscribe(usuario => {
      currentUser = usuario

      if(currentUser){
        request = request.clone(
          {
            setHeaders: {
              Authorization: `Bearer ${currentUser.token}`
            }
          }
        );
      }
    });



    return next.handle(request);
  }
}
