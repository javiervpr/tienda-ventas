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

  constructor(
    public ventaService: VentaService,
    public dialog: MatDialog,
    private router: Router,
  ) {

  }

  ngOnInit(): void {
  }

  abrirCarrito() {
    const dialogRef = this.dialog.open(CarritoComponent);
  }

  historialDeCompras() {
    this.router.navigate(['/historial']);
  }

  cerrarSesion() {
    this.router.navigate(['/login']);
  }

  editarPerfil() {
    this.router.navigate(['/perfil']);
  }
}
