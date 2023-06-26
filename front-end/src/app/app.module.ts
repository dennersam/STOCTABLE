import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/material.modules';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidemenuComponent } from './shared/layout/sidemenu/sidemenu.component';
import { SideNavComponent } from './shared/layout/side-nav/side-nav.component';
import { BodyComponent } from './shared/layout/body/body.component';
import { HeaderComponent } from './shared/layout/header/header.component';


@NgModule({
  declarations: [
    AppComponent,
    SidemenuComponent,
    SideNavComponent,
    BodyComponent,
    HeaderComponent

  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: "pt"}],
  bootstrap: [AppComponent]
})
export class AppModule { }
