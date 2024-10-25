'use client';

import {
  LineChart,
  XAxis,
  YAxis,
  Line,
  Tooltip,
  CartesianGrid,
} from 'recharts';
import { eachDayOfInterval, isSameDay, format } from 'date-fns';

import { ChartContainer } from '@/components/ui/chart';

import { GetMembersByDateResponse } from '../../types';

interface MembersJoinedDateLineChartProps {
  members: GetMembersByDateResponse[];
  dateRange: {
    from: Date;
    to: Date;
  };
}

export function MembersJoinedDateLineChart({
  members,
  dateRange: { from, to },
}: MembersJoinedDateLineChartProps) {
  const data = eachDayOfInterval({
    start: from,
    end: to,
  }).map(d => {
    const m = members.filter(m => isSameDay(new Date(m.joinedDate), d));

    return {
      date: d,
      count: m.length,
      members: m,
    };
  });
  return (
    <ChartContainer config={{}}>
      <LineChart data={data}>
        <XAxis dataKey="date" angle={-45} tickFormatter={(v: Date) => format(v, 'dd-LL-yyyy')} />
        <YAxis dataKey="count" />
        <Tooltip />
        <Line type="linear" stroke="black" activeDot={{ r: 8 }} />
        <CartesianGrid />
      </LineChart>
    </ChartContainer>
  );
}