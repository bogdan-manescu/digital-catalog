import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../services/auth.service";
import User from "../models/user.model";

@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // return new Observable<boolean>((obs) => {
    //   this.authService.userData.subscribe((res: User) => {
    //     if (res) {
    //       return true;
    //     }
    //     this.router.navigate(["login"]);
    //     return false;
    //   });
    // });

    if (localStorage.getItem("userData")) {
      return true;
    }

    this.router.navigate(["login"]);
    return false;
  }
}
