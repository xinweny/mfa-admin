import { PaymentMethod } from './payment-method';

export interface UpdateDueRequest {
  amountPaid: number;
  year: number;
  paymentMethod: PaymentMethod;
  paymentDate: Date;
}