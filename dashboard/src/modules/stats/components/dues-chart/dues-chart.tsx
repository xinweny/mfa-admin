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

import { DuesPieChart } from './components/dues-pie-chart';
import { DueYearSelect } from './components/due-year-select';

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
    <Card className="bg-secondary w-[400px]">
      <CardHeader className="flex flex-row justify-between items-center p-4 space-y-0">
        <CardTitle>Membership Dues</CardTitle>
        <DueYearSelect />
      </CardHeader>
      <CardContent className="p-4">
        <DuesPieChart
          amountOwed={summary.data.totalYearlyDuesOwed}
          amountPaid={summary.data.totalYearlyDuesPaid}
        />
      </CardContent>
    </Card>
  );
}