import { ApiResponse } from '@/core/api/types';
import { GetMembersSummaryResponse } from '../../types';

import { NumberCard } from '../number-card';

export async function TotalMembersCard() {
  const res = await fetch(`${process.env.MFA_API_URL}/members/summary`);

  const summary: ApiResponse<GetMembersSummaryResponse> = await res.json();

  console.log(summary);

  return (
    <NumberCard
      value={summary.data?.totalCount || 0}
      label="Total Members"
    />
  );
}