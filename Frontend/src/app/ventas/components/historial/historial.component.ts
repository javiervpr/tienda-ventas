import { Component, OnInit } from '@angular/core';
import { VentaService } from '../../services/venta.service';

@Component({
  selector: 'app-historial',
  templateUrl: './historial.component.html',
  styleUrls: ['./historial.component.css']
})
export class HistorialComponent implements OnInit {

  historial = [];

  constructor(
    public ventaService: VentaService
  ) { }

  ngOnInit() {
    this.obtenerHistorial();
  }

  obtenerHistorial() {
    this.ventaService.obtenerHistorialVentas(localStorage.getItem('userID')).subscribe((res: any) => {
      this.historial = res;
    });
  }

}
