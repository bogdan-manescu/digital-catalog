import { Component, OnInit } from "@angular/core";
import { Event, GuardsCheckEnd, NavigationEnd, Router } from "@angular/router";
import { AuthService } from "./services/auth.service";
import User from "./models/user.model";
import AOS from "aos";
@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent implements OnInit {
  title = "DigitalCatalog";

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    let userData: User = JSON.parse(localStorage.getItem("userData"));

    if (userData) {
      this.authService.userData.next(userData);
      this.router.navigate(["dashboard"]);
    }

    AOS.init();
  }
}
