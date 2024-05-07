import DocumentType from "./document-type.model";
import User from "./user.model";

export default class Document {
  id: number;
  userId: number;
  user: User;
  documentTypeId: number;
  documentType: DocumentType;
  description: string;
  isPending: boolean;
  isDeclined: boolean;
  startDate: string;
  endDate: string;
}
