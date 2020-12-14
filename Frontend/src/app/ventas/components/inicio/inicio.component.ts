import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { VentaService } from '../../services/venta.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  listaProductos = [];

  constructor(
    public ventaService: VentaService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
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

}
