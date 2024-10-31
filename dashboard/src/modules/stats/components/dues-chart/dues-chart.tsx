import { ApiResponse } from '@/core/api/types';
import { GetMembershipDueTotalsResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';

import {
  getMembershipDuesUrlParams,
  serializeGetMembershipDuesUrlParams,
} from '../../state';

import {
  Card,
  CardHeader,
  CardContent,
  CardTitle,
} from '@/components/ui/card';

import { DuesPieChart } from './dues-pie-chart';
import { DueYearSelect } from './due-year-select';

interface DuesChartProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function DuesChart({
  searchParams,
}: DuesChartProps) {
  const params = getMembershipDuesUrlParams.parse(searchParams);

  const url = serializeGetMembershipDuesUrlParams(
    'memberships/summary/dues',
    params
  );

  const res = await mfaApiFetch(url);

  const summary: ApiResponse<GetMembershipDueTotalsResponse> = await res.json();

  if (!summary.data) return null;

  return (
    <Card className="bg-secondary">
      <CardHeader className="flex flex-row justify-between items-center p-4 space-y-0">
        <CardTitle>Membership Dues</CardTitle>
        <DueYearSelect />
      </CardHeader>
      <CardContent className="p-4">
        <DuesPieChart
          amountOwed={summary.data.totalDues}
          amountPaid={summary.data.totalDuesPaid}
        />
      </CardContent>
    </Card>
  );
}