import { Address } from '@/modules/address/types';
import { MembershipType } from './membership-type';

export interface GetMembershipsResponse {
  id: string;
  membershipType: MembershipType;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
  due: {
    id: string;
    year: number;
  } | null;
  addressId: string | null;
  address: Address | null;
  startDate: string | null;
  createdAt: string;
  updatedAt: string | null;
}