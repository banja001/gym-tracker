import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Login } from '../model/login.model';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'xp-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar

  ) {}

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  login(): void {
    const login: Login = {
      username: this.loginForm.value.username || "",
      password: this.loginForm.value.password || "",
    };

    if (this.loginForm.valid) {
      this.authService.login(login).subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: (err) => {
        if (err.status === 404) {
           this.snackBar.open('Wrong credentials', 'Close', {
          duration: 3000, 
          panelClass: ['error-snackbar'],
          verticalPosition: 'bottom' 
          });
        } else {
           this.snackBar.open('Login error', 'Close', {
          duration: 3000,
          panelClass: ['error-snackbar'],
          verticalPosition: 'bottom' 
          });
        }
      }
    });
    }
    else 
    {
      this.loginForm.markAllAsTouched();
    }
  }
}
