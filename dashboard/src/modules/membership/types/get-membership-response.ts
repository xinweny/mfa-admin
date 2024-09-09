import { Address } from '@/modules/address/types';
import { MembershipType } from './membership-type';

export interface GetMembershipResponse {
  id: string;
  membershipType: MembershipType;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[] | null;
  addressId: string | null;
  address: Address | null;
  startDate: string;
}