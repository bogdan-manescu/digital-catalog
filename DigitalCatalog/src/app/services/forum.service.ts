import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { AuthResponseData } from "./auth.service";
import { Observable } from "rxjs";
import Comment from "../models/comment.model";

@Injectable({
  providedIn: "root",
})
export class ForumService {
  baseUrl: string = `${environment.apiUrl}/Forum`;

  constructor(private http: HttpClient) {}

  getForum(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-forum`);
  }

  createComment(comment: Comment): Observable<AuthResponseData> {
    return this.http.post<AuthResponseData>(`${this.baseUrl}/create-comment`, comment);
  }
}
