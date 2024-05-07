import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class OverlayService {
  message = new Subject<string>();
  isError = new Subject<boolean>();
  isCalled = new Subject<boolean>();

  constructor() {}

  openOverlay(message: string, isError: boolean): void {
    this.isCalled.next(true);
    this.isError.next(isError);
    this.message.next(message);
  }

  closeOverlay(): void {
    this.isCalled.next(false);
  }

  throwError(): void {
    this.openOverlay("An error has ocured!", true);
  }
}
