import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { URL_API } from '../../core/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private headers = {
    headers: new HttpHeaders({'Content-type': 'application/json'})
  };

  constructor(
    private http: HttpClient
  ) { }

  login(correo, contrasenha) {
    const url = URL_API + 'api/clientes/login';
    const body = {
      email: correo,
      password: contrasenha
    };
    return this.http.post(url, this.headers);
  }

  registrar(nombres, apellidos, email, password) {
    const url = URL_API + 'api/clientes';
    const body = {
      nombres,
      apellidos,
      email,
      password
    };
    return this.http.post(url, body, this.headers);
  }
}
