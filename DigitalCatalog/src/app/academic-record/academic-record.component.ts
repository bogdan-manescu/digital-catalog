import { Component, OnInit, ViewChild } from "@angular/core";
import { AuthResponseData, AuthService } from "../services/auth.service";
import User from "../models/user.model";
import { ScoreService } from "../services/score.service";
import Score from "../models/score.model";
import { MatTableDataSource } from "@angular/material/table";
import { MatSort } from "@angular/material/sort";

@Component({
  selector: "app-academic-record",
  templateUrl: "./academic-record.component.html",
  styleUrls: ["./academic-record.component.scss"],
})
export class AcademicRecordComponent implements OnInit {
  myCreditPoints = 0;
  totalCreditPoints = 0;
  creditPointsPercentage: string;
  isLoading: boolean;
  userData: User;
  academicRecord: Score[];
  displayedColumns: string[] = ["courseName", "teacherName", "creditPoints", "myScore"];

  constructor(private authService: AuthService, private scoreService: ScoreService) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });

    this.isLoading = true;

    this.scoreService.getAcademicRecordByUserId(this.userData.id).subscribe({
      next: (res: AuthResponseData) => {
        this.academicRecord = res.data;

        this.academicRecord.forEach((a: Score) => {
          if (a.totalScore >= 50) {
            this.myCreditPoints += a.course.creditPoints;
          }

          this.totalCreditPoints += a.course.creditPoints;
          this.creditPointsPercentage = ((this.myCreditPoints / this.totalCreditPoints) * 100).toFixed(2);
        });

        console.log(this.academicRecord, this.myCreditPoints);

        this.isLoading = false;
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
      },
    });
  }
}
