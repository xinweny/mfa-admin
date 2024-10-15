import { ApiResponse } from '@/core/api/types';
import { GetMembershipTypeCountsResponse } from '../../types';

import {
  Card,
  CardHeader,
  CardContent,
  CardTitle,
} from '@/components/ui/card';
import { MembershipTypePieChart } from './membership-type-pie-chart';

export async function MembershipTypeChart() {
  const res = await fetch(`${process.env.MFA_API_URL}/memberships/summary/membership-types`);

  const summary: ApiResponse<GetMembershipTypeCountsResponse> = await res.json();

  if (!summary.data) return null;

  return (
    <Card className="bg-secondary">
      <CardHeader>
        <CardTitle>Membership Types</CardTitle>
      </CardHeader>
      <CardContent className="p-4">
        <MembershipTypePieChart
          counts={summary.data}
        />
      </CardContent>
    </Card>
  );
}