import { Address } from '@/modules/address/types';
import { MembershipType } from './membership-type';

export type MembershipColumns = {
  id: string;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
  address: Address | null,
  membershipType: MembershipType;
  startDate: Date | null;
  paidForYear: boolean | null;
}