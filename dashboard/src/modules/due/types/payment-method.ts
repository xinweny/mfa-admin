export enum PaymentMethod {
  Cash = 1,
  EFT = 2,
  Cheque = 3,
}

export const paymentMethodLabels: Record<PaymentMethod, string> = {
  [PaymentMethod.Cash]: 'Cash',
  [PaymentMethod.Cheque]: 'Cheque',
  [PaymentMethod.EFT]: 'EFT',
};