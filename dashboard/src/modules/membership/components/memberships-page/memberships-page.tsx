import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { GetMembershipsRequest } from '../../types';

import { MembershipsTable } from '../memberships-table/memberships-table';
import { DataTableHeader } from '@/modules/data/components/data-table-header';

interface MembershipsPageProps {
  searchParams: GetMembershipsRequest;
}

export async function MembershipsPage({
  searchParams: {
    yearPaid,
    sortStartDate,
  },
}: MembershipsPageProps) {
  const searchParams = new URLSearchParams({
    ...(yearPaid && { yearPaid }),
    ...(sortStartDate && { sortStartDate }),
  });

  const memberships = await fetch(`${process.env.MFA_API_URL}/memberships?` + searchParams.toString())
    .then(data => data.json());

  return (
    <DashboardContent>
      <DataTableHeader text="Memberships" />
      <MembershipsTable
        memberships={memberships.data}
      />
    </DashboardContent>
  );
}