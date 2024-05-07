import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
  providedIn: "root",
})
export class SnackBarService {
  constructor(private sb: MatSnackBar) {}

  openSnackBar(message: string, isError: boolean) {
    this.sb.open(message, "", {
      horizontalPosition: "center",
      verticalPosition: "top",
      panelClass: ["snackbar-success"],
    });

    // if(isError){
    //   this.sb.
    // }
  }
}
