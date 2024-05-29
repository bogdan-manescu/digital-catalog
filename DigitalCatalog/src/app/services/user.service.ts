import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import User from "../models/user.model";
import { Observable } from "rxjs";
import { AuthResponseData } from "./auth.service";

@Injectable({
  providedIn: "root",
})
export class UserService {
  baseUrl: string = `${environment.apiUrl}/User`;

  constructor(private http: HttpClient) {}

  addUser(user: User): Observable<AuthResponseData> {
    return this.http.post<AuthResponseData>(`${this.baseUrl}/add-user`, user);
  }

  getAllUsers(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-all-users`);
  }

  getAllGroups(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-all-groups`);
  }

  getAllFaculties(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-all-faculties`);
  }

  getAllRoles(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-all-roles`);
  }
}
