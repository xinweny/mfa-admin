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

  const summary: ApiResponse<GetMembersByDateResponse> = await res.json();

  console.log(summary);

  if (!summary.data) return null;

  return (
    <Card className="bg-secondary">
      <CardHeader className="flex flex-row justify-between items-center p-4 space-y-0">
        <CardTitle>Members</CardTitle>
      </CardHeader>
      <CardContent className="p-4">
      </CardContent>
    </Card>
  )
}