import { Component, OnInit } from "@angular/core";
import { AuthService } from "../services/auth.service";
import User from "../models/user.model";
import { Router } from "@angular/router";
import { MatDialog } from "@angular/material/dialog";
import { DialogBoxComponent } from "../dialog-box/dialog-box.component";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
  userData: User;

  constructor(private authService: AuthService, private router: Router, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });
  }

  onLogout(): void {
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      data: { name: `${this.userData.firstName}, are you sure you want to logout?` },
    });

    dialogRef.afterClosed().subscribe((res) => {
      if (res === true) {
        localStorage.clear();
        this.router.navigate(["login"]);
      }
    });
  }
}
