import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import User from "src/app/models/user.model";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-dashboard-overview",
  templateUrl: "./dashboard-overview.component.html",
  styleUrls: ["./dashboard-overview.component.scss"],
})
export class DashboardOverviewComponent implements OnInit {
  userData: User;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });
  }
}
