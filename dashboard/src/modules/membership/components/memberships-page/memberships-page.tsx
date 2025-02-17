import { serializeGetMembershipsUrlParams, getMembershipsUrlParams } from '../../state';

import { GetMembershipsResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';
import { ApiResponse } from '@/core/api/types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { MembershipsTable } from '../memberships-table';
import {
  DashboardContentHeader,
  DashboardContentTitle,
} from '@/modules/dashboard/components/dashboard-content-header';
import { DataTableContainer, DataTableMenu } from '@/core/data/components/data-table-container';
import { MembershipsTableFilters } from '../memberships-table-filters';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { CreateEntityLinkButton } from '@/modules/dashboard/components/create-entity-link-button';
import { ExportMembershipsCsvButton } from '../export-memberships-csv-button';

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
  
  const data: ApiResponse<GetMembershipsResponse> = await res.json();

  const memberships = (data.data || []) as GetMembershipsResponse[];

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
        <DataTableMenu>
          <MembershipsTableFilters />
          <ExportMembershipsCsvButton
            memberships={memberships}
          />
        </DataTableMenu>
        <MembershipsTable
          memberships={memberships}
        />
        <DataTablePagination
          pagination={data.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}