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
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { MembersTable } from '../members-table/members-table';
import { MembershipsTableFilters } from '../members-table-filters';

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

  const members: ApiResponse<GetMembersResponse> = await res.json();

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle title="Members" />
      </DashboardContentHeader>
      <DataTableContainer>
        <MembershipsTableFilters />
        <MembersTable
          members={(members.data || []) as GetMembersResponse[]}
        />
        <DataTablePagination
          pagination={members.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}