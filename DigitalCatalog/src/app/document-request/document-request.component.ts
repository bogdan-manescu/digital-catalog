import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import User from "../models/user.model";
import { AuthResponseData, AuthService } from "../services/auth.service";
import DocumentRequest from "../models/create-document-request.model";
import { OverlayService } from "../services/overlay.service";
import { DocumentService } from "../services/document.service";
import DocumentType from "../models/document-type.model";
import Document from "../models/document.model";

@Component({
  selector: "app-document-request",
  templateUrl: "./document-request.component.html",
  styleUrls: ["./document-request.component.scss"],
})
export class DocumentRequestComponent implements OnInit {
  isLoading: boolean;
  documentRequestForm: FormGroup;
  userData: User;
  docTypes: DocumentType[];
  docRequests: Document[];
  displayedColumns: string[] = ["docType", "description", "status", "requestDate", "completionDate"];

  constructor(private authService: AuthService, private documentService: DocumentService, private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });

    this.isLoading = true;

    this.documentService.getDocumentTypes().subscribe({
      next: (res: AuthResponseData) => {
        this.docTypes = res.data;

        this.documentService.getAllDocumentRequestsByUserId(this.userData.id).subscribe({
          next: (res: AuthResponseData) => {
            this.docRequests = res.data;
            console.log(this.docRequests);
            this.isLoading = false;
          },
          error: (err) => {
            console.log(err);
            this.isLoading = false;
            this.overlayService.throwError();
          },
        });
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
        this.overlayService.throwError();
      },
    });

    this.initForm();
  }

  onDocumentRequest(): void {
    if (this.documentRequestForm.valid) {
      this.isLoading = true;
      let doc: DocumentRequest = this.documentRequestForm.value;
      doc.userId = this.userData.id;

      console.log(doc);

      this.documentService.createDocumentRequest(doc).subscribe({
        next: (res: AuthResponseData) => {
          this.docRequests = res.data;
          this.isLoading = false;
          this.overlayService.openOverlay("Your request has been registered successfully!", false);
        },
        error: (err) => {
          console.log(err);
          this.isLoading = false;
          this.overlayService.throwError();
        },
      });
    }
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

  initForm(): void {
    this.documentRequestForm = new FormGroup({
      documentTypeId: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required),
    });
  }
}
