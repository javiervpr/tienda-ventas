import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { VentaService } from './ventas/services/venta.service';
import { CarritoComponent } from './ventas/components/carrito/carrito.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  listaProductos = [];

  constructor(
    public ventaService: VentaService,
    public dialog: MatDialog
  ) {

  }

  ngOnInit(): void {
    this.obtenerProductos();
  }

  obtenerProductos() {
    this.ventaService.obtenerProductos().subscribe( (res: any) => {
      if (res.success) {
        this.listaProductos = res.data;
        console.log(res.data);
      } else {
        console.log(res.message);
      }
    }, (error: any) => {
      console.log(error);
    });
  }

  abrirCarrito() {
    const dialogRef = this.dialog.open(CarritoComponent);
  }
}
