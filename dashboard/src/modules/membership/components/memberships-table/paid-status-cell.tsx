import { format } from 'date-fns';

import { PaymentMethod, paymentMethodLabels } from '@/modules/due/types';

import { useGetMembershipsUrlParams } from '@/modules/membership/state';

import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from '@/components/ui/tooltip';

import { BooleanBadge } from '@/components/ui/boolean-badge';

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

  const badge = <BooleanBadge
    value={hasPaid}
    trueLabel="Paid"
    falseLabel="Unpaid"
  />

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