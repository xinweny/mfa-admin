import { Address } from '@/modules/address/types';
import { MembershipType } from './membership-type';

export interface CreateMembershipRequest {
  membershipType: MembershipType;
  startDate: Date;
  address: Address | null;
  members: {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string | null;
    joinedDate: Date | null;
  }[];
}