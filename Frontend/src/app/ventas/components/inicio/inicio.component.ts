import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { VentaService } from '../../services/venta.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  listaProductosDeportes = [];
  listaProductosModa = [];
  listaProductosOficio = [];
  listaProductosSalud = [];
  listaProductosTecnologia = [];

  constructor(
    public ventaService: VentaService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.obtenerProductos();
  }

  obtenerProductos() {
    this.ventaService.obtenerProductos().subscribe( (res: any) => {
      this.listaProductosModa = res.filter(x => x.categoria === 'Moda');
      this.listaProductosOficio = res.filter(x => x.categoria === 'Oficio');
      this.listaProductosSalud = res.filter(x => x.categoria === 'Salud');
      this.listaProductosDeportes = res.filter(x => x.categoria === 'Deportes');
      this.listaProductosTecnologia = res.filter(x => x.categoria === 'Tecnología');
    }, (error: any) => {
      console.log(error);
    });
  }

}
