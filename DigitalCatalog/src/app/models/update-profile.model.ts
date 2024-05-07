export default class UpdateProfile {
  constructor(
    public id: number,
    public profilePicture: string,
    public firstName: string,
    public lastName: string,
    public email: string,
    public phoneNumber: string,
    public year: number,
    public roleId: number,
    public facultyId: number,
    public groupId: number
  ) {}
}
