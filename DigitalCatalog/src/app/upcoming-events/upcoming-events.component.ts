import { Component, OnInit } from "@angular/core";
import Article from "../models/article.model";
import { ArticleService } from "../services/article.service";
import { OverlayService } from "../services/overlay.service";
import { AuthResponseData } from "../services/auth.service";

@Component({
  selector: "app-upcoming-events",
  templateUrl: "./upcoming-events.component.html",
  styleUrls: ["./upcoming-events.component.scss"],
})
export class UpcomingEventsComponent implements OnInit {
  isLoading: boolean;
  articles: Article[];

  constructor(private articleService: ArticleService, private overlayService: OverlayService) {}

  ngOnInit(): void {
    this.articleService.getArticles().subscribe({
      next: (res: AuthResponseData) => {
        this.articles = res.data;
      },
      error: (err) => {
        console.log(err);
        this.isLoading = false;
        this.overlayService.throwError();
      },
    });
  }

  getArticleDate(articleDate: string): string {
    let d = new Date(articleDate);

    if (articleDate) return `${d.getDate()}/${d.getMonth() + 1}/${d.getFullYear()}`;
    else return "Unknown";
  }
}
