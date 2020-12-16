import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { URL_API } from '../../core/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class VentaService {

  private headers = {
    headers: new HttpHeaders({'Content-type': 'application/json'})
  };

  constructor(
    private http: HttpClient
  ) { }

  obtenerProductos() {
    const url = URL_API + 'api/productos';
    return this.http.get(url, this.headers);
  }

  obtenerHistorialVentas(id) {
    const url = URL_API + 'api/ventas/historial/' + id;
    return this.http.get(url, this.headers);
  }

  registrarVenta(cliente, razonSocial, nit, listaProductos) {
    const url = URL_API + 'api/ventas';
    const body = {
      clienteID: cliente,
      factura: {
        razonSocial,
        nit
      },
      detalleVenta: listaProductos
    };
    console.log(body);
    return this.http.post(url, body, {responseType: 'text'});
  }
}
