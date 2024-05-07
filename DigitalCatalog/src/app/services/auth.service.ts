import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject, tap } from "rxjs";
import { environment } from "src/environments/environment";
import User from "../models/user.model";

export interface AuthResponseData {
  data: any;
  success: boolean;
  message: string;
}

@Injectable({
  providedIn: "root",
})
export class AuthService {
  baseUrl: string = `${environment.apiUrl}/Auth`;
  userData = new BehaviorSubject<User>(null);

  constructor(private http: HttpClient) {
    // this.userData = new Subject<User>();
  }

  login(username: string, password: string): Observable<AuthResponseData> {
    return this.http
      .post<AuthResponseData>(`${this.baseUrl}/login`, {
        username: username,
        password: password,
      })
      .pipe(
        tap((res) => {
          this.userData.next(res.data);
          localStorage.setItem("userData", JSON.stringify(res.data));
        })
      );
  }
}
