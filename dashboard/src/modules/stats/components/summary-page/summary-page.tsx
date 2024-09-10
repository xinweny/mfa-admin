import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { NumberSummaryCards } from '../number-summary-cards';

export function SummaryPage() {
  return (
    <DashboardContent>
      <NumberSummaryCards />
    </DashboardContent>
  );
}