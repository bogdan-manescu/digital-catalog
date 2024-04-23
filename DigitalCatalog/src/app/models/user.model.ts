import Role from "./role.model";

export default interface User {
  id: number;
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  roleId: number;
  role: Role;
}
