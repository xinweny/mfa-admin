import {
  serializeGetExchangesUrlParams,
  getExchangesUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetExchangesResponse } from '../../types';

import { mfaApiFetch } from '@/core/api/utils';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import {
  DashboardContentHeader,
  DashboardContentTitle,
} from '@/modules/dashboard/components/dashboard-content-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { ExchangesTable } from '../exchanges-table';
import { ExchangesTableFilters } from '../exchanges-table-filters';

interface ExchangesPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function ExchangesPage({
  searchParams,
}: ExchangesPageProps) {
  const url = serializeGetExchangesUrlParams(
    'exchanges',
    getExchangesUrlParams.parse(searchParams)
  );
  
  const res = await mfaApiFetch(url);

  const exchanges: ApiResponse<GetExchangesResponse> = await res.json();

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle title="Hosts & Delegates" />
      </DashboardContentHeader>
      <DataTableContainer>
        <ExchangesTableFilters />
        <ExchangesTable
          exchanges={(exchanges.data || []) as GetExchangesResponse[]}
        />
        <DataTablePagination
          pagination={exchanges.metadata?.pagination || null}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}