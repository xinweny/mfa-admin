import { ApiResponse } from '@/core/api/types';
import { GetMembersSummaryResponse } from '../../types';

import { NumberCard } from '../number-card';

export async function NumberSummaryCards() {
  const res = await fetch(`${process.env.MFA_API_URL}/members/summary`);

  const summary: ApiResponse<GetMembersSummaryResponse> = await res.json();

  return (
    <div className="flex items-center flex-wrap gap-4">
      <NumberCard
        value={(summary.data?.totalCount || 0).toString()}
        label="Total Members"
      />
      <NumberCard
        value={`${Math.round((summary.data?.mississaugaRatio || 0) * 100 * 10) / 10}%`}
        label="Misssissauga Residents"
      />
    </div>
  );
}