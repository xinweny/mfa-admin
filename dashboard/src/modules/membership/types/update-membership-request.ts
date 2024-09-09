import { MembershipType } from './membership-type';

export interface UpdateMembershipRequest {
  membershipType: MembershipType;
  startDate: Date;
}