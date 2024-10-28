'use client';

import { useTheme } from 'next-themes';

import {
  LineChart,
  YAxis,
  Line,
  Tooltip,
} from 'recharts';
import { eachDayOfInterval, isSameDay } from 'date-fns';

import { ChartContainer } from '@/components/ui/chart';

import { GetMembersByDateResponse } from '../../types';
import { MemberCountTooltip } from './member-count-tooltip';

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
  const {theme} = useTheme();

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
    <ChartContainer config={{}} className="max-h-[250px] w-full">
      <LineChart data={data}>
        <YAxis dataKey="count" />
        <Tooltip content={<MemberCountTooltip />} />
        <Line
          type="linear"
          stroke={theme == 'dark' ? 'white' : 'black'}
          strokeWidth={2}
          dataKey="count"
          dot={false}
        />
      </LineChart>
    </ChartContainer>
  );
}