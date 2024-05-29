import { Component, OnInit } from "@angular/core";
import User from "../models/user.model";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import Faculty from "../models/faculty.model";
import Group from "../models/group.model";
import { UserService } from "../services/user.service";
import { OverlayService } from "../services/overlay.service";
import { AuthResponseData } from "../services/auth.service";
import Role from "../models/role.model";

@Component({
  selector: "app-user-management",
  templateUrl: "./user-management.component.html",
  styleUrls: ["./user-management.component.scss"],
})
export class UserManagementComponent implements OnInit {
  isLoading: boolean;
  users: User[];
  addUserForm: FormGroup;
  faculties: Faculty[];
  groups: Group[];
  roles: Role[];

  constructor(private userService: UserService, private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.isLoading = true;

    this.userService.getAllUsers().subscribe({
      next: (res: AuthResponseData) => {
        this.users = res.data;

        this.userService.getAllGroups().subscribe({
          next: (res: AuthResponseData) => {
            this.groups = res.data;

            this.userService.getAllFaculties().subscribe({
              next: (res: AuthResponseData) => {
                this.faculties = res.data;

                this.userService.getAllRoles().subscribe({
                  next: (res: AuthResponseData) => {
                    this.roles = res.data;
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

  onAddUser(): void {
    if (this.addUserForm.valid) {
      this.isLoading = true;
      let user = this.addUserForm.value;

      console.log(user);

      this.userService.addUser(user).subscribe({
        next: (res: AuthResponseData) => {
          this.users = res.data;
          this.isLoading = false;
          this.overlayService.openOverlay("User has been added successfully!", false);
        },
        error: (err) => {
          console.log(err);
          this.isLoading = false;
          this.overlayService.throwError();
        },
      });
    }
  }

  initForm(): void {
    this.addUserForm = new FormGroup({
      firstName: new FormControl("", Validators.required),
      lastName: new FormControl("", Validators.required),
      username: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
      email: new FormControl("", [Validators.required, Validators.email]),
      phoneNumber: new FormControl("", Validators.required),
      facultyId: new FormControl("", Validators.required),
      groupId: new FormControl("", Validators.required),
      year: new FormControl("", Validators.required),
      roleId: new FormControl("", Validators.required),
    });
  }
}
