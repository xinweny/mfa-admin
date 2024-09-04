import {
  serializeGetExchangesUrlParams,
  getExchangesUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetExchangesResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import {
  DashboardContentHeader,
  DashboardContentHeading,
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
    `${process.env.MFA_API_URL}/exchanges`,
    getExchangesUrlParams.parse(searchParams)
  );

  const exchanges: ApiResponse<GetExchangesResponse> = await fetch(url)
    .then(data => data.json());

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentHeading text="Hosts & Delegates" />
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