import { HeaderRowOutlet } from '@angular/cdk/table';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {

  @Input() id: number;
  @Input() nombre: string;
  @Input() precio: number;
  @Input() cantidad: number;

  agregado = false;
  favorito = false;

  constructor() { }

  ngOnInit() {
  }

  agregarFavorito() {
    this.favorito = !this.favorito;
  }

  agregarCarrito() {
    this.agregado = !this.agregado;
  }

  detalleProducto() {
    alert('hola');
  }

}
