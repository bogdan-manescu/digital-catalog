import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthResponseData, AuthService } from "./auth.service";
import { Observable, tap } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class ScoreService {
  baseUrl: string = `${environment.apiUrl}/Score`;

  constructor(private http: HttpClient, private authService: AuthService) {}

  getAcademicRecordByUserId(userId: number): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-academic-record-by-user-id/${userId}`);
  }
}
