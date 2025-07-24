import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Registration } from '../model/registration.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'xp-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
    
  ) {}

  registrationForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  register(): void {
    const registration: Registration = {
      firstName: this.registrationForm.value.firstName || "",
      lastName: this.registrationForm.value.lastName || "",
      username: this.registrationForm.value.username || "",
      password: this.registrationForm.value.password || "",
    };
    console.log(this.registrationForm.valid)
    if (this.registrationForm.valid) {
      this.authService.register(registration).subscribe({
        next: () => {
          this.router.navigate(['']);
        },
        error: (err) => { 
          this.snackBar.open('Registration failed. Please check your information and try again.', 'Close', {
          duration: 3000,
          panelClass: ['error-snackbar'],
          verticalPosition: 'bottom' 
          });
        
      }
    });
    }
  }
}
