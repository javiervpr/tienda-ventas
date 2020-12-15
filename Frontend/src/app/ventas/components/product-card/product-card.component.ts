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
  @Input() imagen: string;
  @Input() categoria: string;
  @Input() precio: number;
  @Input() cantidad: number;

  agregado = false;
  favorito = false;

  constructor() { }

  ngOnInit() {
    this.verificarExistenciaEnCarrito(this.id);
  }

  agregarFavorito() {
    this.favorito = !this.favorito;
  }

  agregarCarrito(id, nombre, imagen, precio, categoria) {
    this.agregado = !this.agregado;
    let carrito = JSON.parse(localStorage.getItem('carrito'));
    if (this.agregado) {
      const aux = {id, nombre, imagen, precio, categoria, cantidad: 1};
      if (carrito == null) {
        carrito = [];
      }
      carrito.push(aux);
      localStorage.setItem('carrito', JSON.stringify(carrito));
    } else {
      const index = this.findWithAttr(carrito, 'id', id);
      if (index > -1) {
        carrito.splice(index, 1);
      }
      localStorage.setItem('carrito', JSON.stringify(carrito));
    }
  }

  detalleProducto() {
    alert('hola');
  }

  verificarExistenciaEnCarrito(id) {
    const carrito = JSON.parse(localStorage.getItem('carrito'));
    const index = this.findWithAttr(carrito, 'id', id);
    if (index > -1) {
      this.agregado = true;
    }
  }

  findWithAttr(array, attr, value) {
    for (let i = 0; i < array.length; i += 1) {
        if(array[i][attr] === value) {
            return i;
        }
    }
    return -1;
  }

}
