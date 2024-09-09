import { serializeGetMembershipsUrlParams, getMembershipsUrlParams } from '../../state';

import { GetMembershipsResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import {
  DashboardContentHeader,
  DashboardContentHeading,
} from '@/modules/dashboard/components/dashboard-content-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { MembershipsTableFilters } from '../memberships-table-filters';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { ApiResponse } from '@/core/api/types';
import { CreateEntityLinkButton } from '@/modules/dashboard/components/create-entity-link-button';

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

  const res = await fetch(url);
  
  const memberships: ApiResponse<GetMembershipsResponse> = await res.json();

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentHeading text="Memberships" />
        <CreateEntityLinkButton
          path="memberships/new"
          label="Membership"
        />
      </DashboardContentHeader>
      <DataTableContainer>
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