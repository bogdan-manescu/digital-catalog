import { Component, OnInit } from "@angular/core";
import { OverlayService } from "../services/overlay.service";

@Component({
  selector: "app-overlay",
  templateUrl: "./overlay.component.html",
  styleUrls: ["./overlay.component.scss"],
})
export class OverlayComponent implements OnInit {
  isCalled = false;
  isError = false;
  message = "";

  constructor(private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.overlayService.isCalled.subscribe((res) => {
      this.isCalled = res;

      if (this.isCalled) {
        setTimeout(() => {
          this.overlayService.closeOverlay();
        }, 2750);
      }
    });
    this.overlayService.isError.subscribe((res) => (this.isError = res));
    this.overlayService.message.subscribe((res) => (this.message = res));
  }
}
