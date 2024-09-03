import {
  serializeGetDuesUrlParams,
  getDuesUrlParams,
} from '../../state';

import { ApiResponse } from '@/core/api/types';
import { GetDuesResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { DataTableHeader } from '@/core/data/components/data-table-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';

interface DuesPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function DuesPage({
  searchParams,
}: DuesPageProps) {
  const dues: ApiResponse<GetDuesResponse> = await fetch(
    serializeGetDuesUrlParams(
      `${process.env.MFA_API_URL}/dues`,
      getDuesUrlParams.parse(searchParams)
    ))
    .then(data => data.json());

  return (
    <DashboardContent>
      <DataTableContainer>
        <DataTableHeader text="Dues" />
      </DataTableContainer>
    </DashboardContent>
  );
}