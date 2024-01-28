import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { ContaService } from '../usuario/services/conta.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {

  constructor(
    private contaService: ContaService,
    private router: Router
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
   ) : Observable<boolean> | boolean {
    if(this.contaService.usuarioEstaAutenticado()){
      return true;
    }

    this.router.navigate(['/usuario/login']);
    return false;


  }
}
