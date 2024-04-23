import { Component, OnInit } from "@angular/core";
import { AuthService } from "../services/auth.service";
import User from "../models/user.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
  userData: User;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });
  }

  onLogout(): void {
    localStorage.clear();
    this.router.navigate(["login"]);
  }
}
