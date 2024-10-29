export interface CreateMemberRequest {
  membershipId: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string | null;
  joinedDate: Date | null;
}