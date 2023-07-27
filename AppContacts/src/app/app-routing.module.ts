import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadoContactosComponent } from './components/listado-contactos/listado-contactos.component';
import { AgregarEditarContactoComponent } from './components/agregar-editar-contacto/agregar-editar-contacto.component';
import { VerContactoComponent } from './components/ver-contacto/ver-contacto.component';


const routes: Routes = [
  {path: '', redirectTo: 'listContacts', pathMatch: 'full'},
  {path: 'listContacts', component: ListadoContactosComponent},
  {path: 'addContact', component: AgregarEditarContactoComponent},
  {path: 'detailContact/:id', component: VerContactoComponent},
  {path: 'editContact/:id', component: AgregarEditarContactoComponent},
  {path: '**', redirectTo: 'listContacts', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
