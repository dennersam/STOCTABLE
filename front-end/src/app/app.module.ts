import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import ptBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideNavComponent } from './shared/layout/side-nav/side-nav.component';
import { BodyComponent } from './shared/layout/body/body.component';
import { HeaderComponent } from './shared/layout/header/header.component';

import { UsuarioModule } from './usuario/usuario.module';
import { CadastroModule } from './cadastro/cadastro.module';
import { AuthGuard } from './guard/auth.guard';
import { ContaService } from './usuario/services/conta.service';
import { ToastrModule } from 'ngx-toastr';
import { JwtInterceptor } from './interceptors/jwt.interceptor';

registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    SideNavComponent,
    BodyComponent,
    HeaderComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CadastroModule,
    UsuarioModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true
    }),
  ],
  providers: [
    { provide: LOCALE_ID, useValue: "pt"},
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'BRL' },
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    ContaService, AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
