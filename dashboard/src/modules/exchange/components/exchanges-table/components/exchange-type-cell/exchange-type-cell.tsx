import { ExchangeType, exchangeTypeLabels } from '@/modules/exchange/types';

import { Badge } from '@/components/ui/badge';

interface ExchangeTypeCellProps {
  exchangeType: ExchangeType;
}

export function ExchangeTypeCell({
  exchangeType,
}: ExchangeTypeCellProps) {
  return (
    <Badge>
      {exchangeTypeLabels[exchangeType]}
    </Badge>
  );
}