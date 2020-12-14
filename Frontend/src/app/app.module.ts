import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ProductCardComponent } from './ventas/components/product-card/product-card.component';
import { CarritoComponent } from './ventas/components/carrito/carrito.component';
import { DetalleProductoComponent } from './ventas/components/detalle-producto/detalle-producto.component';
import { LoginComponent } from './ventas/components/login/login.component';
import { RegistrarComponent } from './ventas/components/registrar/registrar.component';
import { InicioComponent } from './ventas/components/inicio/inicio.component';
import { HistorialComponent } from './ventas/components/historial/historial.component';
import { PerfilComponent } from './ventas/components/perfil/perfil.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductCardComponent,
    CarritoComponent,
    DetalleProductoComponent,
    LoginComponent,
    RegistrarComponent,
    InicioComponent,
    HistorialComponent,
    PerfilComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    CarritoComponent
  ]
})
export class AppModule { }
