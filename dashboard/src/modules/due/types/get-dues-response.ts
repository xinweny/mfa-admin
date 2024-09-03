import { MembershipType } from '@/modules/membership/types';
import { PaymentMethod } from './payment-method';

export interface GetDuesResponse {
  id: string;
  year: number;
  amountPaid: number;
  paymentDate: string | null;
  paymentMethod: PaymentMethod;
  membershipId: string;
  membership: {
    id: string;
    membershipType: MembershipType
    members: {
      id: string;
      firstName: string;
      lastName: string;
    }[];
  } | null;
}