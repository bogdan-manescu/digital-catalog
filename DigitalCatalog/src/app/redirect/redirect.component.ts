import { Component, OnInit } from "@angular/core";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-redirect",
  templateUrl: "./redirect.component.html",
  styleUrls: ["./redirect.component.scss"],
})
export class RedirectComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res) => {
      if (res) {
        this.router.navigate(["dashboard"]);
      } else {
        this.router.navigate(["login"]);
      }
    });
  }
}
