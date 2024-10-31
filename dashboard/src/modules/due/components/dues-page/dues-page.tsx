import {
  serializeGetDuesUrlParams,
  getDuesUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetDuesResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import {
  DashboardContentHeader,
  DashboardContentTitle,
} from '@/modules/dashboard/components/dashboard-content-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { CreateEntityLinkButton } from '@/modules/dashboard/components/create-entity-link-button';

import { DuesTable } from '../dues-table';
import { DuesTableFilters } from '../dues-table-filters';

interface DuesPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function DuesPage({
  searchParams,
}: DuesPageProps) {
  const url = serializeGetDuesUrlParams(
    'dues',
    getDuesUrlParams.parse(searchParams)
  );

  const res = await mfaApiFetch(url);

  const dues: ApiResponse<GetDuesResponse> = await res.json();

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle title="Dues" />
        <CreateEntityLinkButton
          path="dues/new"
          label="Create Receipts"
        />
      </DashboardContentHeader>
      <DataTableContainer>
        <DuesTableFilters />
        <DuesTable
          dues={(dues.data || []) as GetDuesResponse[]}
        />
        <DataTablePagination
          pagination={dues.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}