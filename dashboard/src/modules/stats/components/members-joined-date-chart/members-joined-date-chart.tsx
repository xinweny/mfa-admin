import {
  getMembersByDateUrlParams,
  serializeGetMembersByDateUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetMembersByDateResponse } from '../../types';

import {
  Card,
  CardHeader,
  CardContent,
  CardTitle,
} from '@/components/ui/card';

import { JoinedDateRangeSelect } from './joined-date-range-select';
import { MembersJoinedDateLineChart } from './members-joined-date-line-chart';

interface MembersJoinedDateChartProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function MembersJoinedDateChart({
  searchParams,
}: MembersJoinedDateChartProps) {
  const params = getMembersByDateUrlParams.parse(searchParams);

  const url = serializeGetMembersByDateUrlParams(
    `${process.env.MFA_API_URL}/members/summary/joined`,
    params
  );

  const res = await fetch(url);

  const summary: ApiResponse<GetMembersByDateResponse[]> = await res.json();

  if (!summary.data) return null;

  return (
    <Card className="bg-secondary h-96 flex flex-col">
      <CardHeader className="flex flex-row justify-between items-center p-4 space-y-0">
        <CardTitle>New Member Trends</CardTitle>
        <JoinedDateRangeSelect />
      </CardHeader>
      <CardContent className="p-4 flex-shrink">
        <MembersJoinedDateLineChart
          members={summary.data}
          dateRange={{
            from: params.joinedFrom,
            to: params.joinedTo,
          }}
        />
      </CardContent>
    </Card>
  )
}