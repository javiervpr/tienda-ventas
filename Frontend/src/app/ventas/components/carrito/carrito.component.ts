import { Component, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { MatDialog } from '@angular/material/dialog';
import { PagoDetalleComponent } from '../pago-detalle/pago-detalle.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class CarritoComponent implements OnInit {

  carritoProductos = [];

  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['Nombre', 'Precio por unidad', 'Cantidad', 'Precio total'];
  expandedElement: PeriodicElement | null;

  constructor(
    public dialog: MatDialog,
    private toastr: ToastrService,
  ) { }

  ngOnInit() {
    this.obtenerCarrito();
    console.log('carrito', this.carritoProductos.length);
  }

  obtenerCarrito() {
    this.carritoProductos = JSON.parse(localStorage.getItem('carrito'));
    if (this.carritoProductos == null) {
      this.carritoProductos = [];
    }
  }

  pagar() {
    const loged = localStorage.getItem('loged');
    console.log(loged);
    if (loged === 'true') {
      const dialogRef = this.dialog.open(PagoDetalleComponent);
    } else {
      this.toastr.warning('Debe iniciar sesión', null, {
        progressBar: true,
        timeOut: 3000
      });
    }
  }

  vaciarCarrito() {
    const carrito = [];
    localStorage.setItem('carrito', JSON.stringify(carrito));
    this.obtenerCarrito();
  }

}

export interface PeriodicElement {
  Nombre: string;
  Cantidad: number;
  Precio: number;
  symbol: string;
  description: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    Cantidad: 1,
    Nombre: 'Hydrogen',
    Precio: 1.0079,
    symbol: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Cantidad: 2,
    Nombre: 'Helium',
    Precio: 4.0026,
    symbol: 'He',
    description: `Helium is a chemical element with symbol He and atomic number 2. It is a
        colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
        group in the periodic table. Its boiling point is the lowest among all the elements.`
  }, {
    Cantidad: 3,
    Nombre: 'Lithium',
    Precio: 6.941,
    symbol: 'Li',
    description: `Lithium is a chemical element with symbol Li and atomic number 3. It is a soft,
        silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
        lightest solid element.`
  }, {
    Cantidad: 4,
    Nombre: 'Beryllium',
    Precio: 9.0122,
    symbol: 'Be',
    description: `Beryllium is a chemical element with symbol Be and atomic number 4. It is a
        relatively rare element in the universe, usually occurring as a product of the spallation of
        larger atomic nuclei that have collided with cosmic rays.`
  }, {
    Cantidad: 5,
    Nombre: 'Boron',
    Precio: 10.811,
    symbol: 'B',
    description: `Boron is a chemical element with symbol B and atomic number 5. Produced entirely
        by cosmic ray spallation and supernovae and not by stellar nucleosynthesis, it is a
        low-abundance element in the Solar system and in the Earth's crust.`
  }, {
    Cantidad: 6,
    Nombre: 'Carbon',
    Precio: 12.0107,
    symbol: 'C',
    description: `Carbon is a chemical element with symbol C and atomic number 6. It is nonmetallic
        and tetravalent—making four electrons available to form covalent chemical bonds. It belongs
        to group 14 of the periodic table.`
  }, {
    Cantidad: 7,
    Nombre: 'Nitrogen',
    Precio: 14.0067,
    symbol: 'N',
    description: `Nitrogen is a chemical element with symbol N and atomic number 7. It was first
        discovered and isolated by Scottish physician Daniel Rutherford in 1772.`
  }, {
    Cantidad: 8,
    Nombre: 'Oxygen',
    Precio: 15.9994,
    symbol: 'O',
    description: `Oxygen is a chemical element with symbol O and atomic number 8. It is a member of
         the chalcogen group on the periodic table, a highly reactive nonmetal, and an oxidizing
         agent that readily forms oxides with most elements as well as with other compounds.`
  }, {
    Cantidad: 9,
    Nombre: 'Fluorine',
    Precio: 18.9984,
    symbol: 'F',
    description: `Fluorine is a chemical element with symbol F and atomic number 9. It is the
        lightest halogen and exists as a highly toxic pale yellow diatomic gas at standard
        conditions.`
  }, {
    Cantidad: 10,
    Nombre: 'Neon',
    Precio: 20.1797,
    symbol: 'Ne',
    description: `Neon is a chemical element with symbol Ne and atomic number 10. It is a noble gas.
        Neon is a colorless, odorless, inert monatomic gas under standard conditions, with about
        two-thirds the density of air.`
  },
];
