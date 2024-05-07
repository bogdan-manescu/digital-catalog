import User from "./user.model";

export default interface Article {
  id: number;
  title: string;
  description: string;
  thumbnail: string;
  authorId: number;
  author: User;
  created: string;
}
