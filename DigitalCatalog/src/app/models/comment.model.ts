import User from "./user.model";

export default interface Comment {
  id: number;
  userId: number;
  user: User;
  message: string;
  postedAt: string;
  attachedFile: string;
}
