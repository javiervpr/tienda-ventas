import { Component, OnInit } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css']
})
export class RegistrarComponent implements OnInit {

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]);
  confirmPassword = new FormControl('', [ Validators.required, 
                                          Validators.minLength(4), 
                                          Validators.maxLength(100),
                                          Validators.pattern(this.password.value)]);
  nombres = new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]);
  apellidos = new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]);;
  constructor(
    private authService: AuthService
  ) { }

  ngOnInit() {
  }

  enviar() {
    // if (this.confirmPassword.hasError('confirmPassword')) {
    //   alert('Las contraseñas no coinciden')
    //   return;
    // }
    this.authService.registrar(this.nombres.value, this.apellidos.value, this.email.value, this.password.value)
      .subscribe(result => {
        console.log(result);
      });
  }
}
