import Course from "./course.model";
import User from "./user.model";

export default interface Score {
  id: number;
  courseId: number;
  course: Course;
  studentId: number;
  student: User;
  totalScore: number;
}
