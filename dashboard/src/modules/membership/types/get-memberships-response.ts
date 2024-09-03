import { Address } from '@/modules/address/types';
import { MembershipType } from './membership-type';
import { PaymentMethod } from '@/modules/due/types';

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
    paymentDate: string | null;
    amountPaid: number;
    paymentMethod: PaymentMethod;
  } | null;
  addressId: string | null;
  address: Address | null;
  startDate: string;
  createdAt: string;
  updatedAt: string | null;
}