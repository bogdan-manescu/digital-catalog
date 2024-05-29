import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from "@angular/core";
import Comment from "../models/comment.model";
import { OverlayService } from "../services/overlay.service";
import { ForumService } from "../services/forum.service";
import { AuthResponseData, AuthService } from "../services/auth.service";
import User from "../models/user.model";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ScrollService } from "../services/scroll.service";

@Component({
  selector: "app-forum",
  templateUrl: "./forum.component.html",
  styleUrls: ["./forum.component.scss"],
})
export class ForumComponent implements OnInit, OnDestroy {
  isLoading: boolean;
  comments: Comment[];
  userData: User;
  commentForm: FormGroup;
  isScrolledToLatest = false;
  forumInterval: any;
  isCommentDisabled = false;
  latestForumLen: number;

  constructor(
    private authService: AuthService,
    private forumService: ForumService,
    private overlayService: OverlayService,
    private scrollService: ScrollService
  ) {}

  ngOnInit(): void {
    this.authService.userData.subscribe((res: User) => {
      this.userData = res;
    });

    this.isLoading = true;

    this.forumInterval = setInterval(() => {
      this.forumService.getForum().subscribe({
        next: (res: AuthResponseData) => {
          this.comments = res.data;
          this.isLoading = false;

          if (!this.isScrolledToLatest || this.comments.length - this.latestForumLen > 0) {
            this.scrollService.scrollToBottom();
            this.isScrolledToLatest = true;
          }

          this.latestForumLen = this.comments.length;
        },
        error: (err) => {
          console.log(err);
          this.isLoading = false;
          this.overlayService.throwError();
        },
      });
    }, 1000);

    this.initForm();
  }

  ngAfterViewInit(): void {}

  ngOnDestroy(): void {
    clearInterval(this.forumInterval);
  }

  getCommentDate(commentDate: string): string {
    const now = new Date();
    const date = new Date(commentDate);
    const seconds = Math.floor((now.getTime() - date.getTime()) / 1000);

    let interval = Math.floor(seconds / 31536000);
    if (interval >= 1) {
      return interval === 1 ? `${interval} year ago` : `${interval} years ago`;
    }
    interval = Math.floor(seconds / 2592000);
    if (interval >= 1) {
      return interval === 1 ? `${interval} month ago` : `${interval} months ago`;
    }
    interval = Math.floor(seconds / 86400);
    if (interval >= 1) {
      return interval === 1 ? `${interval} day ago` : `${interval} days ago`;
    }
    interval = Math.floor(seconds / 3600);
    if (interval >= 1) {
      return interval === 1 ? `${interval} hour ago` : `${interval} hours ago`;
    }
    interval = Math.floor(seconds / 60);
    if (interval >= 1) {
      return interval === 1 ? `${interval} minute ago` : `${interval} minutes ago`;
    }
    return seconds === 1 ? `${seconds} second ago` : `${seconds} seconds ago`;
  }

  initForm(): void {
    this.commentForm = new FormGroup({
      message: new FormControl(""),
    });
  }

  onCreateComment(): void {
    if (this.commentForm.valid && this.commentForm.controls["message"].value.trim().length !== 0) {
      let comment: Comment = this.commentForm.value;
      comment.message = comment.message.trim();
      comment.userId = this.userData.id;
      comment.attachedFile = "";
      this.isCommentDisabled = true;

      console.log(comment);

      this.forumService.createComment(comment).subscribe({
        next: (res: AuthResponseData) => {
          this.comments = res.data;
          this.isCommentDisabled = false;
          this.commentForm.reset();
          this.commentForm.controls["message"].setValue("");
          this.scrollService.scrollToBottom();
        },
        error: (err) => {
          console.log(err);
          this.overlayService.throwError();
        },
      });
    }
  }
}
