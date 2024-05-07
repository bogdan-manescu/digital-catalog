import Faculty from "./faculty.model";
import Group from "./group.model";
import Role from "./role.model";

export default interface User {
  id: number;
  profilePicture: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  year: number;
  username: string;
  password: string;
  roleId: number;
  role: Role;
  facultyId: number;
  faculty: Faculty;
  groupId: number;
  group: Group;
}
