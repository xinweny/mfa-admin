import { format } from 'date-fns';

import { cn } from '@/lib/cn';

import { PaymentMethod, paymentMethodLabels } from '@/modules/dues/types';

import { useGetMembershipsUrlParams } from '@/modules/membership/state';

import { Badge } from '@/components/ui/badge';
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from '@/components/ui/tooltip';

interface PaidStatusCellProps {
  startDate: Date;
  due: {
    id: string;
    year: number;
    paymentDate: Date | null;
    amountPaid: number;
    paymentMethod: PaymentMethod;
  } | null;
}

export function PaidStatusCell({
  startDate,
  due,
}: PaidStatusCellProps) {
  const [{ yearPaid }] = useGetMembershipsUrlParams();

  if (yearPaid < startDate.getFullYear()) return null;

  const hasPaid = !!due;

  const badge = <Badge
    className={cn(
      'text-white',
      hasPaid
        ? 'bg-green-800 hover:bg-green-700'
        : 'bg-red-800 hover:bg-red-700'
    )}
  >
    {hasPaid ? 'Paid' : 'Unpaid'}
  </Badge>;

  if (!hasPaid) return badge;

  const dueData = [
    { label: 'Year', value: due.year },
    { label: 'Amount Paid ($)', value: due.amountPaid },
    { label: 'Payment Method', value: paymentMethodLabels[due.paymentMethod] },
    { label: 'Payment Date', value: due.paymentDate ? format(due.paymentDate, 'dd/LL/yyyy') : null },
  ];

  return (
    <TooltipProvider>
      <Tooltip>
        <TooltipTrigger>{badge}</TooltipTrigger>
        <TooltipContent>
          <ul>
            {dueData.map(data => (
              <li key={data.label} className="flex justify-between gap-8 [&:not(:last-child)]:border-b p-2">
                <span className="font-semibold">{data.label}</span>
                <span>{data.value}</span>
              </li>
            ))}
          </ul>
        </TooltipContent>
      </Tooltip>
    </TooltipProvider>
  );
}