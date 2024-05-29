import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ScrollService {
  constructor() {}

  scrollToBottom(): void {
    const element = document.getElementById("scrollContainer");

    console.log(element.scrollHeight);

    if (element) {
      element.scrollTop = element.scrollHeight + 1000;
    }
  }
}
