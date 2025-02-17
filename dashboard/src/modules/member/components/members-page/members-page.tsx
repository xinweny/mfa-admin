import {
  serializeGetMembersUrlParams,
  getMembersUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetMembersResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import {
  DashboardContentHeader,
  DashboardContentTitle,
} from '@/modules/dashboard/components/dashboard-content-header';
import { DataTableContainer, DataTableMenu } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { MembersTable } from '../members-table/members-table';
import { MembershipsTableFilters } from '../members-table-filters';
import { ExportMembersCsvButton } from '../export-members-csv-button';

interface MembersPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function MembersPage({
  searchParams,
}: MembersPageProps) {
  const url = serializeGetMembersUrlParams(
    'members',
    getMembersUrlParams.parse(searchParams)
  );

  const res = await mfaApiFetch(url);

  const data: ApiResponse<GetMembersResponse> = await res.json();

  const members = (data.data || []) as GetMembersResponse[];

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle title="Members" />
      </DashboardContentHeader>
      <DataTableContainer>
        <DataTableMenu>
          <MembershipsTableFilters />
          <ExportMembersCsvButton members={members} />
        </DataTableMenu>
        <MembersTable members={members} />
        <DataTablePagination
          pagination={data.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}