import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { NumberSummaryCards } from '../number-summary-cards';
import { DuesChart } from '../dues-chart';
import { MembershipTypeChart } from '../membership-type-chart';

interface SummaryPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export function SummaryPage({
  searchParams,
}: SummaryPageProps) {
  return (
    <DashboardContent>
      <NumberSummaryCards />
      <div className="grid grid-cols-3 gap-4">
        <DuesChart searchParams={searchParams} />
        <MembershipTypeChart searchParams={searchParams} />
      </div>
    </DashboardContent>
  );
}