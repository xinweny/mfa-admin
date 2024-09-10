import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { NumberSummaryCards } from '../number-summary-cards';
import { DuesChart } from '../dues-chart';

interface SummaryPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export function SummaryPage({
  searchParams,
}: SummaryPageProps) {
  return (
    <DashboardContent>
      <NumberSummaryCards />
      <DuesChart searchParams={searchParams} />
    </DashboardContent>
  );
}