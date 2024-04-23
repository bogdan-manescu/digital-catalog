import { OnInit, isStandalone } from "@angular/core";
import { Component } from "@angular/core";
import { Validators } from "@angular/forms";
import { FormControl } from "@angular/forms";
import { FormGroup } from "@angular/forms";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  isLoading: boolean;
  toggleWarning = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
    });
  }

  onLogin(): void {
    if (this.loginForm.valid) {
      this.isLoading = true;
      this.toggleWarning = false;

      this.authService.login(this.loginForm.controls["username"].value, this.loginForm.controls["password"].value).subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(["dashboard"]);
          this.isLoading = false;
        },
        error: (err) => {
          console.log(err);
          this.toggleWarning = true;
          this.isLoading = false;
        },
      });
    }
  }
}
