import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { GetMembershipsRequest } from '../../types';

import { MembershipsTable } from '../memberships-table/memberships-table';

interface MembershipsPageProps {
  searchParams: GetMembershipsRequest;
}

export async function MembershipsPage({
  searchParams: {
    year,
    sortStartDate,
  },
}: MembershipsPageProps) {
  const searchParams = new URLSearchParams({
    ...(year && { year }),
    ...(sortStartDate && { sortStartDate }),
  });

  const memberships = await fetch(`${process.env.MFA_API_URL}/memberships?` + searchParams.toString())
    .then(data => data.json());

  return (
    <DashboardContent>
      <MembershipsTable
        memberships={memberships.data}
      />
    </DashboardContent>
  );
}