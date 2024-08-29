import { cn } from '@/lib/cn';

import { Badge } from '@/components/ui/badge';

interface PaidStatusCellProps {
  hasPaid: boolean;
}

export function PaidStatusCell({
  hasPaid,
}: PaidStatusCellProps) {
  return (
    <Badge
      className={cn(
        'text-white',
        hasPaid
          ? 'bg-green-800 hover:bg-green-700'
          : 'bg-red-800 hover:bg-red-700'
      )}
    >
      {hasPaid ? 'Paid' : 'Not Paid'}
    </Badge>
  );
}