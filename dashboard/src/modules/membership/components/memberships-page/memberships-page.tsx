import { serializeGetMembershipsUrlParams, getMembershipsUrlParams } from '../../state';

import { GetMembershipsResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import { DataTableHeader } from '@/core/data/components/data-table-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { MembershipsTableFilters } from '../memberships-table-filters';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { ApiResponse } from '@/core/api/types';

interface MembershipsPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function MembershipsPage({
  searchParams,
}: MembershipsPageProps) {
  const url = serializeGetMembershipsUrlParams(
    `${process.env.MFA_API_URL}/memberships`,
    getMembershipsUrlParams.parse(searchParams)
  );

  const memberships: ApiResponse<GetMembershipsResponse> = await fetch(url)
    .then(data => data.json());

  return (
    <DashboardContent>
      <DataTableContainer>
        <DataTableHeader text="Memberships" />
        <MembershipsTableFilters />
        <MembershipsTable
          memberships={(memberships.data || []) as GetMembershipsResponse[]}
        />
        <DataTablePagination
          pagination={memberships.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}