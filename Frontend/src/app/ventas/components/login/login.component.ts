import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule  } from '@angular/forms';

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

  constructor() { }

  ngOnInit() {
  }

  login() {

  }

}
