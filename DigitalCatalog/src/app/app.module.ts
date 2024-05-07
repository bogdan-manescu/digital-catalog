import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { LoginComponent } from "./login/login.component";
import { MatCommonModule } from "@angular/material/core";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { ReactiveFormsModule } from "@angular/forms";
import { MatInputModule } from "@angular/material/input";
import { MatIconModule } from "@angular/material/icon";
import { HttpClientModule } from "@angular/common/http";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { RedirectComponent } from "./redirect/redirect.component";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MyProfileComponent } from "./my-profile/my-profile.component";
import { AcademicRecordComponent } from "./academic-record/academic-record.component";
import { UpcomingEventsComponent } from "./upcoming-events/upcoming-events.component";
import { DocumentRequestComponent } from "./document-request/document-request.component";
import { ForumComponent } from "./forum/forum.component";
import { MatDialogModule } from "@angular/material/dialog";
import { DialogBoxComponent } from "./dialog-box/dialog-box.component";
import { DashboardOverviewComponent } from "./dashboard/dashboard-overview/dashboard-overview.component";
import { OverlayComponent } from "./overlay/overlay.component";
import { LoaderComponent } from "./loader/loader.component";
import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";
import { MatSelectModule } from "@angular/material/select";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    RedirectComponent,
    MyProfileComponent,
    AcademicRecordComponent,
    UpcomingEventsComponent,
    DocumentRequestComponent,
    ForumComponent,
    DialogBoxComponent,
    DashboardOverviewComponent,
    OverlayComponent,
    LoaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCommonModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatDialogModule,
    MatTableModule,
    MatSortModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
