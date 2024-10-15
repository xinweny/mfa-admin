import { MembershipType } from '@/modules/membership/types';

export interface GetMembersByDateResponse {
  id: string;
  firstName: string;
  lastName: string;
  joinedDate: Date;
  membershipId: string;
  membership: {
    membershipId: string;
    membershipType: MembershipType;
  }
}