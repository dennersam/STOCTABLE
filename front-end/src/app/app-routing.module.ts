import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: "", redirectTo: 'dashboard', pathMatch:'full' },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'estoque',
    loadChildren: () => import('./estoque/estoque.module').then(m => m.EstoqueModule)
  },
  {
    path: 'usuario',
    loadChildren: () => import('./usuario/usuario.module').then(m => m.UsuarioModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule{}
