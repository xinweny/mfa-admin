import { PaymentMethod } from './payment-method';

export interface CreateDuesRequest {
  dues: {
    membershipId: string;
    year: number;
    amountPaid: number;
    paymentMethod: PaymentMethod;
    paymentDate: Date;
  }[];
}