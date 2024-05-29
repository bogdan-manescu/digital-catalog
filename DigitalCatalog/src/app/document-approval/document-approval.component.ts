import { Component, OnInit } from "@angular/core";
import User from "../models/user.model";
import Document from "../models/document.model";
import DocumentType from "../models/document-type.model";
import { AuthResponseData, AuthService } from "../services/auth.service";
import { DocumentService } from "../services/document.service";
import { OverlayService } from "../services/overlay.service";

@Component({
  selector: "app-document-approval",
  templateUrl: "./document-approval.component.html",
  styleUrls: ["./document-approval.component.scss"],
})
export class DocumentApprovalComponent implements OnInit {
  isLoading: boolean;
  userData: User;
  docTypes: DocumentType[];
  docApprovals: Document[];
  displayedColumns: string[] = ["docType", "description", "status", "requestDate", "completionDate", "actions"];

  constructor(private authService: AuthService, private documentService: DocumentService, private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });

    this.isLoading = true;

    this.documentService.getAllDocumentRequestsByStudyYear(this.userData.year).subscribe({
      next: (res: AuthResponseData) => {
        this.docApprovals = res.data;
        console.log(this.docApprovals);
        this.isLoading = false;
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
        this.overlayService.throwError();
      },
    });
  }

  getDocStatus(doc: Document): String {
    if (!doc.isDeclined) {
      if (doc.isPending) return "Pending";
      else return "Ready";
    } else return "Declined";
  }

  getDocDate(docDate: string): string {
    let d = new Date(docDate);

    if (docDate) return `${d.getDate()}/${d.getMonth() + 1}/${d.getFullYear()}`;
    else return "Unknown";
  }

  onSetDocStatus(documentId: number, isDeclined: boolean): void {
    this.isLoading = true;

    this.documentService.setDocumentRequestStatus(documentId, this.userData.id, isDeclined).subscribe({
      next: (res: AuthResponseData) => {
        this.docApprovals = res.data;
        this.isLoading = false;
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
        this.overlayService.throwError();
      },
    });
  }
}
