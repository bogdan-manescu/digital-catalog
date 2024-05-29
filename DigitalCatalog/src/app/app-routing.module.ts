import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { AuthGuard } from "./guards/auth.guard";
import { RedirectComponent } from "./redirect/redirect.component";
import { MyProfileComponent } from "./my-profile/my-profile.component";
import { AcademicRecordComponent } from "./academic-record/academic-record.component";
import { DocumentRequestComponent } from "./document-request/document-request.component";
import { UpcomingEventsComponent } from "./upcoming-events/upcoming-events.component";
import { ForumComponent } from "./forum/forum.component";
import { DashboardOverviewComponent } from "./dashboard/dashboard-overview/dashboard-overview.component";
import { UserManagementComponent } from "./user-management/user-management.component";
import { ClassroomEditorComponent } from "./classroom-editor/classroom-editor.component";
import { DocumentApprovalComponent } from "./document-approval/document-approval.component";

const routes: Routes = [
  { path: "", redirectTo: "/login", pathMatch: "full" },
  { path: "login", component: LoginComponent },
  {
    path: "dashboard",
    component: DashboardComponent,
    canActivate: [AuthGuard],
    children: [
      { path: "", component: DashboardOverviewComponent, canActivate: [AuthGuard] },
      { path: "my-profile", component: MyProfileComponent, canActivate: [AuthGuard] },
      { path: "academic-record", component: AcademicRecordComponent, canActivate: [AuthGuard] },
      { path: "document-request", component: DocumentRequestComponent, canActivate: [AuthGuard] },
      { path: "latest-news", component: UpcomingEventsComponent, canActivate: [AuthGuard] },
      { path: "user-management", component: UserManagementComponent, canActivate: [AuthGuard] },
      { path: "classroom-editor", component: ClassroomEditorComponent, canActivate: [AuthGuard] },
      { path: "document-approval", component: DocumentApprovalComponent, canActivate: [AuthGuard] },
      { path: "forum", component: ForumComponent, canActivate: [AuthGuard] },
    ],
  },
  { path: "**", component: RedirectComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
