import { Address } from '@/modules/address/types';
import { MembershipType } from '@/modules/membership/types';

export interface GetMembersResponse {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string | null;
  joinedDate: string | null;
  membershipId: string;
  membership: {
    id: string;
    membershipType: MembershipType;
    addressId: string | null;
    address: Address | null;
    isActive: boolean;
  };
}