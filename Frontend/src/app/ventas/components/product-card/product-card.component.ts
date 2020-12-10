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

  constructor() { }

  ngOnInit() {
  }

  agregarFavorito() {
    
  }

}
