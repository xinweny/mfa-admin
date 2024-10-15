import {
  getMembersByDateUrlParams,
  serializeGetMembersByDateUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetMembersByDateResponse } from '../../types';

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

  if (!summary.data) return null;

  return 
}