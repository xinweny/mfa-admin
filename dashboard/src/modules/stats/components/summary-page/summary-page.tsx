import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { TotalMembersCard } from '../total-members-card';

export function SummaryPage() {
  return (
    <DashboardContent>
      <div className="grid grid-cols-3">
        <TotalMembersCard />
      </div>
    </DashboardContent>
  );
}