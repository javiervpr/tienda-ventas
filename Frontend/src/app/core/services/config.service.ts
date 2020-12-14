import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }
}

// export let URL_API = 'http://127.0.0.1:4000/';
export let URL_API = 'https://localhost:44388/';
export let PORT_CONF = 8000;
