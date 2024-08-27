'use client';

import {
  GetMembershipsResponse,
  MembershipColumns,
} from '../../types';

import { DataTable } from '@/modules/dashboard/components/data-table';

import { columns } from './columns';

interface MembershipsTableProps {
  memberships: GetMembershipsResponse[];
}

export function MembershipsTable({
  memberships,
}: MembershipsTableProps) {
  const data: MembershipColumns[] = memberships.map(membership => ({
    id: membership.id,
    membershipType: membership.membershipType,
    members: membership.members,
    address: membership.address || null,
    startDate: membership.startDate
      ? new Date(membership.startDate)
      : null,
    paidForYear: membership.dues?.length > 0,
  }));

  return (
    <DataTable
      columns={columns}
      data={data}
    />
  );
}