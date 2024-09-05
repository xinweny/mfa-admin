import { PaymentMethod, paymentMethodLabels } from '@/modules/due/types';

import { Badge } from '@/components/ui/badge';

interface PaymentMethodCellProps {
  paymentMethod: PaymentMethod;
}

export function PaymentMethodCell({
  paymentMethod,
}: PaymentMethodCellProps) {
  return (
    <Badge>
      {paymentMethodLabels[paymentMethod]}
    </Badge>
  );
}