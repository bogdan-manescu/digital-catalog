import User from "./user.model";

export default interface Course {
  id: number;
  name: string;
  creditPoints: number;
  teacherId: number;
  teacher: User;
}
