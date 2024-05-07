import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthResponseData, AuthService } from "../services/auth.service";
import User from "../models/user.model";
import { ProfileService } from "../services/profile.service";
import UpdateProfile from "../models/update-profile.model";
import { OverlayService } from "../services/overlay.service";
import UpdateLoginCredentials from "../models/update-login-credentials.model";

@Component({
  selector: "app-my-profile",
  templateUrl: "./my-profile.component.html",
  styleUrls: ["./my-profile.component.scss"],
})
export class MyProfileComponent implements OnInit {
  myProfileForm: FormGroup;
  loginCredentialsForm: FormGroup;
  profilePicturePreview = "../../assets/noPreview.png";
  encodedProfilePicture: string;
  isLoading: boolean;
  userData: User;

  constructor(private authService: AuthService, private profileService: ProfileService, private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });

    this.initForms();
  }

  handleFileInput(e: any): void {
    let fileToUpload = e.files[0];
    let reader = new FileReader();

    reader.onload = (event: any) => {
      this.profilePicturePreview = event.target.result as string;
    };

    reader.onloadend = () => {
      this.encodedProfilePicture = reader.result as string;
      this.myProfileForm.controls["profilePicture"].setValue(this.encodedProfilePicture);
    };

    reader.readAsDataURL(fileToUpload);
  }

  onSaveMyProfile(): void {
    if (this.myProfileForm.valid) {
      this.isLoading = true;
      let { id, roleId, facultyId, groupId } = this.userData;
      let { profilePicture, firstName, lastName, email, phoneNumber, year } = this.myProfileForm.value;
      let profile = new UpdateProfile(id, profilePicture, firstName, lastName, email, phoneNumber, year, roleId, facultyId, groupId);

      if (this.myProfileForm.value.profilePicture) {
        profile.profilePicture = this.encodedProfilePicture;
      }

      console.log(profile);

      this.profileService.updateProfile(profile).subscribe({
        next: () => {
          this.isLoading = false;
          this.overlayService.openOverlay("Your profile has been saved successfully!", false);
        },
        error: (err) => {
          console.log(err);
          this.isLoading = false;
          this.overlayService.throwError();
        },
      });
    }
  }

  onSaveLoginCredentials(): void {
    if (this.loginCredentialsForm.valid) {
      this.isLoading = true;
      let loginCredentials: UpdateLoginCredentials = this.loginCredentialsForm.value;
      loginCredentials.id = this.userData.id;

      console.log(loginCredentials);

      this.profileService.updateLoginCredentials(loginCredentials).subscribe({
        next: () => {
          this.isLoading = false;
          this.overlayService.openOverlay("Your login credentials have been saved successfully!", false);
        },
        error: (err) => {
          console.log(err);
          this.isLoading = false;
          this.overlayService.throwError();
        },
      });
    }
  }

  initForms(): void {
    this.myProfileForm = new FormGroup({
      profilePicture: new FormControl(this.userData.profilePicture || this.profilePicturePreview),
      firstName: new FormControl(this.userData.firstName || "", Validators.required),
      lastName: new FormControl(this.userData.lastName || "", Validators.required),
      email: new FormControl(this.userData.email || "", [Validators.required, Validators.email]),
      phoneNumber: new FormControl(this.userData.phoneNumber || "", Validators.required),
      faculty: new FormControl(this.userData.faculty.name || "", Validators.required),
      group: new FormControl(this.userData.group.name || "", Validators.required),
      year: new FormControl(this.userData.year || "", Validators.required),
    });

    this.loginCredentialsForm = new FormGroup({
      username: new FormControl(this.userData.username || "", Validators.required),
      password: new FormControl(this.userData.password || "", Validators.required),
    });
  }
}
