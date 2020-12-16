import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { FormControl, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';
import { VentaService } from '../../services/venta.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-pago-detalle',
  templateUrl: './pago-detalle.component.html',
  styleUrls: ['./pago-detalle.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class PagoDetalleComponent implements OnInit {

  formPagar = new FormGroup({
    razonSocial: new FormControl('', Validators.required),
    nit: new FormControl('', Validators.required)
  });

  constructor(
    public ventaService: VentaService,
    private toastr: ToastrService,
    public router: Router,
    private dialogRef: MatDialogRef<PagoDetalleComponent>
  ) { }

  ngOnInit() {
  }

  pagar() {
    const cliente = localStorage.getItem('userID');
    const razonSocial = ((this.formPagar.value.razonSocial == null) ? '' : this.formPagar.value.razonSocial);
    const nit = ((this.formPagar.value.nit == null) ? '' : this.formPagar.value.nit.toString());
    const carrito = JSON.parse(localStorage.getItem('carrito'));
    const listaProductos = [];
    carrito.forEach(prod => {
      const aux = {
        cantidad: prod.cantidad,
        producto: {
          id: prod.id
        }
      };
      listaProductos.push(aux);
    });
    this.ventaService.registrarVenta(cliente, razonSocial, nit, listaProductos).subscribe( (res: any) => {
      const carritoVacio = [];
      localStorage.setItem('carrito', JSON.stringify(carritoVacio));
      this.toastr.success('Compra realizada con éxito', null, {
        progressBar: true,
        timeOut: 3000
      });
      this.dialogRef.close();
      this.router.navigate(['/']);
    }, (error: any) => {
      this.toastr.error('Ocurrió un error al realizar la venta', null, {
        progressBar: true,
        timeOut: 3000
      });
    });
  }

}
