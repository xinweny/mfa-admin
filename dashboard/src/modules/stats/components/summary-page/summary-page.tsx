import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { MemberSummaryCards } from '../member-summary-cards';
import { DuesChart } from '../dues-chart';
import { MembershipTypeChart } from '../membership-type-chart';
import { MembersJoinedDateChart } from '../members-joined-date-chart';

interface SummaryPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export function SummaryPage({
  searchParams,
}: SummaryPageProps) {
  return (
    <DashboardContent>
      <MemberSummaryCards />
      <div className="grid grid-cols-3 gap-4">
        <DuesChart searchParams={searchParams} />
        <MembershipTypeChart />
        <div className="col-span-3">
          <MembersJoinedDateChart searchParams={searchParams} />
        </div>
      </div>
    </DashboardContent>
  );
}