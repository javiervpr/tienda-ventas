import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { CarritoComponent } from './ventas/components/carrito/carrito.component';
import { VentaService } from './ventas/services/venta.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  loged: boolean;
  usuarioNombre = '';

  constructor(
    public ventaService: VentaService,
    public dialog: MatDialog,
    private router: Router,
  ) {

  }

  ngOnInit(): void {
    if (localStorage.getItem('loged') === 'true') {
      this.usuarioNombre = localStorage.getItem('user_fullname');
      this.loged = true;
    } else {
      this.loged = false;
    }
  }

  abrirCarrito() {
    // const dialogRef = this.dialog.open(CarritoComponent);
    this.router.navigate(['/carrito']);
  }

  historialDeCompras() {
    this.router.navigate(['/historial']);
  }

  editarPerfil() {
    this.router.navigate(['/perfil']);
  }

  cerrarSesion() {
    localStorage.setItem('loged', 'false');
    const carrito = [];
    localStorage.setItem('carrito', JSON.stringify(carrito));
    window.location.reload();
  }
}
