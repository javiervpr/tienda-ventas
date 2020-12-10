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
    const url = URL_API + 'product/products';
    return this.http.get(url, this.headers);
  }
}
