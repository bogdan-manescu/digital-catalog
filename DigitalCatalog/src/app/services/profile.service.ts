import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { AuthResponseData, AuthService } from "./auth.service";
import UpdateProfile from "../models/update-profile.model";
import UpdateLoginCredentials from "../models/update-login-credentials.model";

@Injectable({
  providedIn: "root",
})
export class ProfileService {
  baseUrl: string = `${environment.apiUrl}/Profile`;

  constructor(private http: HttpClient, private authService: AuthService) {}

  updateProfile(profile: UpdateProfile): Observable<AuthResponseData> {
    return this.http.patch<AuthResponseData>(`${this.baseUrl}/update-profile`, profile).pipe(
      tap((res) => {
        this.authService.userData.next(res.data);
        localStorage.setItem("userData", JSON.stringify(res.data));
      })
    );
  }

  updateLoginCredentials(loginCredentials: UpdateLoginCredentials): Observable<AuthResponseData> {
    return this.http.patch<AuthResponseData>(`${this.baseUrl}/update-login-credentials`, loginCredentials).pipe(
      tap((res) => {
        this.authService.userData.next(res.data);
        localStorage.setItem("userData", JSON.stringify(res.data));
      })
    );
  }
}
