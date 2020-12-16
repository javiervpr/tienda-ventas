import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'tr[app-carrito-producto]',
  templateUrl: './carrito-producto.component.html',
  styleUrls: ['./carrito-producto.component.css']
})
export class CarritoProductoComponent implements OnInit {

  @Input() id: number;
  @Input() nombre: string;
  @Input() imagen: string;
  @Input() categoria: string;
  @Input() precio: number;
  @Input() cantidad: number;
  precioTotal = 0;
  @Output() actualizarCarrito = new EventEmitter();

  constructor() { }

  ngOnInit() {
    this.precioTotal = this.precio * this.cantidad;
  }

  aumentarCantidad() {
    this.cantidad++;
    this.precioTotal = this.precio * this.cantidad;
    const carrito = JSON.parse(localStorage.getItem('carrito'));
    const producto = carrito.find((prod) => {
      return prod.id === this.id;
    });
    producto.cantidad = this.cantidad;
    localStorage.setItem('carrito', JSON.stringify(carrito));
  }

  disminuirCantidad() {
    if  (this.cantidad > 1) {
      this.cantidad--;
      this.precioTotal = this.precio * this.cantidad;
      const carrito = JSON.parse(localStorage.getItem('carrito'));
      const producto = carrito.find((prod) => {
        return prod.id === this.id;
      });
      producto.cantidad = this.cantidad;
      localStorage.setItem('carrito', JSON.stringify(carrito));
      }
  }

  removerProducto() {
    const carrito = JSON.parse(localStorage.getItem('carrito'));
    const index = this.findWithAttr(carrito, 'id', this.id);
    if (index > -1) {
      carrito.splice(index, 1);
    }
    localStorage.setItem('carrito', JSON.stringify(carrito));
    this.actualizarCarrito.emit(null);
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
