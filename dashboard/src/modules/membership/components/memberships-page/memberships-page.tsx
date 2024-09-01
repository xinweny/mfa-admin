import { serializeGetMembershipsRequest, getMembershipsUrlParams } from '../../state';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import { DataTableHeader } from '@/modules/data/components/data-table-header';
import { DataTableContainer } from '@/modules/data/components/data-table-container';
import { MembershipsTableFilters } from '../memberships-table-filters';

interface MembershipsPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function MembershipsPage({
  searchParams,
}: MembershipsPageProps) {
  const memberships = await fetch(
    serializeGetMembershipsRequest(
      `${process.env.MFA_API_URL}/memberships`,
      getMembershipsUrlParams.parse(searchParams)
    ))
    .then(data => data.json());

  return (
    <DashboardContent>
      <DataTableContainer>
        <DataTableHeader text="Memberships" />
        <MembershipsTableFilters />
        <MembershipsTable
          memberships={memberships.data || []}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}