import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgregarEditarContactoComponent } from './components/agregar-editar-contacto/agregar-editar-contacto.component';
import { ListadoContactosComponent } from './components/listado-contactos/listado-contactos.component';
import { VerContactoComponent } from './components/ver-contacto/ver-contacto.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    AgregarEditarContactoComponent,
    ListadoContactosComponent,
    VerContactoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
