export interface UpdateMemberRequest {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string | null;
  joinedDate: Date | null;
}