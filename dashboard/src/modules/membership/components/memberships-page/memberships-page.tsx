import { GetMembershipsRequest } from '../../types';

import { getMembershipsSerializer } from '../../state';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import { DataTableHeader } from '@/modules/data/components/data-table-header';
import { DataTableContainer } from '@/modules/data/components/data-table-container';
import { MembershipsTableFilters } from '../memberships-table-filters';

interface MembershipsPageProps {
  searchParams: GetMembershipsRequest;
}

export async function MembershipsPage({
  searchParams,
}: MembershipsPageProps) {
  const memberships = await fetch(
    getMembershipsSerializer(
      `${process.env.MFA_API_URL}/memberships`,
      searchParams
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