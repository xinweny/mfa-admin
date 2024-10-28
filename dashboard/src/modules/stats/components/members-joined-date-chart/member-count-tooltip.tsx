import { TooltipProps } from 'recharts';

import { format } from 'date-fns';

interface MemberCountTooltipProps extends TooltipProps<any, string> {}

export function MemberCountTooltip({
  active = false,
  payload = [],

}: MemberCountTooltipProps) {
  if (!active || payload.length == 0) return null;

  const data = payload[0].payload;

  return (
    <div className="bg-primary-foreground rounded-sm p-2 flex flex-col">
      <span className="font-semibold">{format(data.date, 'd LLL yyyy')}</span>
      <span><span className="font-bold">{data.members.length}</span> members</span>
    </div>
  );
}