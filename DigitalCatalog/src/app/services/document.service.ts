import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import DocumentRequest from "../models/create-document-request.model";
import { Observable } from "rxjs";
import { AuthResponseData } from "./auth.service";

@Injectable({
  providedIn: "root",
})
export class DocumentService {
  baseUrl: string = `${environment.apiUrl}/Document`;

  constructor(private http: HttpClient) {}

  createDocumentRequest(doc: DocumentRequest): Observable<AuthResponseData> {
    return this.http.put<AuthResponseData>(`${this.baseUrl}/create-document-request`, doc);
  }

  getAllDocumentRequestsByUserId(userId: number): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-all-document-requests-by-user-id/${userId}`);
  }

  getDocumentTypes(): Observable<AuthResponseData> {
    return this.http.get<AuthResponseData>(`${this.baseUrl}/get-document-types`);
  }
}
