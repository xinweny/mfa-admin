import { ApiResponse } from '@/core/api/types';
import { GetMembersCountsResponse } from '../../types';

import { NumberCard } from '../number-card';

export async function MemberSummaryCards() {
  const res = await fetch(`${process.env.MFA_API_URL}/members/summary/counts`);

  const summary: ApiResponse<GetMembersCountsResponse> = await res.json();

  if (!summary.data) return null;

  const { totalCount, mississaugaCount } = summary.data;

  return (
    <div className="flex items-center flex-wrap gap-4">
      <NumberCard
        value={totalCount.toString()}
        label="Total Members"
      />
      <NumberCard
        value={`${Math.round((mississaugaCount / totalCount) * 100 * 10) / 10}%`}
        label="Misssissauga Residents"
      />
    </div>
  );
}