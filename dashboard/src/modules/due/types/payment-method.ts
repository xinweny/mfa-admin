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

export const paymentMethodOptions = [
  {
    value: PaymentMethod.Cash,
    label: paymentMethodLabels[PaymentMethod.Cash],
  },
  {
    value: PaymentMethod.EFT,
    label: paymentMethodLabels[PaymentMethod.EFT],
  },
  {
    value: PaymentMethod.Cheque,
    label: paymentMethodLabels[PaymentMethod.Cheque],
  },
];