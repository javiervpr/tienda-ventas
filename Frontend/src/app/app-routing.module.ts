import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './ventas/components/login/login.component';
import { RegistrarComponent } from './ventas/components/registrar/registrar.component';
import { DetalleProductoComponent } from './ventas/components/detalle-producto/detalle-producto.component';
import { InicioComponent } from './ventas/components/inicio/inicio.component';
import { HistorialComponent } from './ventas/components/historial/historial.component';
import { PerfilComponent } from './ventas/components/perfil/perfil.component';


const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registrar', component: RegistrarComponent },
  { path: 'historial', component: HistorialComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: 'detalle/:id', component: DetalleProductoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
