import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide = true;
  formError = '';
  formLogin = new FormGroup({
    nombre_usuario: new FormControl('', Validators.required),
    contrasenha: new FormControl('', Validators.required)
  });

  constructor(
    public authService: AuthService,
    public router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.formLogin.value.nombre_usuario, this.formLogin.value.contrasenha).subscribe((respuesta: any) => {
      localStorage.setItem('userID', respuesta.id);
      localStorage.setItem('nombre', respuesta.nomres + ' - ' + respuesta.apellidos);
      localStorage.setItem('loged', 'true');
      this.router.navigate(['/']).then(() => {
        window.location.reload();
      });
    }, (error: any) => {
      this.toastr.error('Usuario y/o contraseña incorrectos', null, {
        progressBar: true,
        timeOut: 3000
      });
    });

  }

}
