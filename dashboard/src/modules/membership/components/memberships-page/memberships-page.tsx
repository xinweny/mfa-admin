import { serializeGetMembershipsUrlParams, getMembershipsUrlParams } from '../../state';

import { GetMembershipsResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import {
  DashboardContentHeader,
  DashboardContentTitle,
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
    'memberships',
    getMembershipsUrlParams.parse(searchParams)
  );

  const res = await mfaApiFetch(url);
  
  const memberships: ApiResponse<GetMembershipsResponse> = await res.json();

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle title="Memberships" />
        <CreateEntityLinkButton
          path="memberships/new"
          label="New Membership"
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