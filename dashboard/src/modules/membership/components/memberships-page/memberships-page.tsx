import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { MembershipsTable } from '../memberships-table/memberships-table';

export async function MembershipsPage() {
  const memberships = await fetch(`${process.env.MFA_API_URL}/memberships`)
    .then(data => data.json());

  return (
    <DashboardContent>
      <MembershipsTable
        memberships={memberships.data}
      />
    </DashboardContent>
  );
}