import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthResponseData } from "./auth.service";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class ArticleService {
  baseUrl: string = `${environment.apiUrl}/Article`;

  constructor(private http: HttpClient) {}

  getArticles(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-articles`);
  }
}
