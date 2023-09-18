import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string="";
  password: string="";
  role: string="";

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    console.log(this.role);

    // Call the authentication service to login
    this.authService.login(this.username, this.password, this.role).subscribe(
      (user) => {
console.log(user);
console.log(user.user.role);
        if (user.message === 'Login successful' && user.user.role === "ADMIN") {
          this.router.navigate(['/organizer']); // Navigate to the Admin component
        } else if (user.message === 'Login successful' && user.user.role === 'ORGANIZER') {
          this.router.navigate(['/organizer']); // Navigate to the Organizer component
        }
      },
      (error) => {
        // Handle login error, display a message, etc.
        console.error("Login error:", error);
      }
    );
  }
}
