import {
  serializeGetMembersUrlParams,
  getMembersUrlParams,
} from '../../state/get-members-request';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { DataTableHeader } from '@/core/data/components/data-table-header';
import { DataTableContainer } from '@/core/data/components/data-table-container';
import { DataTablePagination } from '@/core/data/components/data-table-pagination';
import { MembersTable } from '../members-table/members-table';

interface MembersPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function MembersPage({
  searchParams,
}: MembersPageProps) {
  const members = await fetch(
    serializeGetMembersUrlParams(
      `${process.env.MFA_API_URL}/members`,
      getMembersUrlParams.parse(searchParams)
    ))
    .then(data => data.json());

  return (
    <DashboardContent>
      <DataTableContainer>
        <DataTableHeader text="Members" />
        <MembersTable
          members={members.data || []}
        />
      </DataTableContainer>
    </DashboardContent>
  );
}