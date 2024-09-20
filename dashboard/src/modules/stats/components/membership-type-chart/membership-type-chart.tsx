import { ApiResponse } from '@/core/api/types';
import { GetMembershipsSummaryResponse } from '../../types';

import {
  getMembershipsSummaryUrlParams,
  serializeGetMembershipsSummaryUrlParams,
} from '../../state';

import {
  Card,
  CardHeader,
  CardContent,
  CardTitle,
} from '@/components/ui/card';

interface DuesChartProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function DuesChart({
  searchParams,
}: DuesChartProps) {
  const params = getMembershipsSummaryUrlParams.parse(searchParams);

  const url = serializeGetMembershipsSummaryUrlParams(
    `${process.env.MFA_API_URL}/memberships/summary`,
    params
  );

  const res = await fetch(url);

  const summary: ApiResponse<GetMembershipsSummaryResponse> = await res.json();

  if (!summary.data) return null;

  return (
    <Card className="bg-secondary">
      <CardHeader>
        <CardTitle>Membership Dues</CardTitle>
      </CardHeader>
      <CardContent className="p-4">
      </CardContent>
    </Card>
  );
}