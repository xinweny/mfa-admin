'use client';

import { GetMembershipsResponse } from '../../types';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTable } from '@/modules/data/components/data-table';

import { MembershipColumns, columns } from './columns';

interface MembershipsTableProps {
  memberships: GetMembershipsResponse[];
}

export function MembershipsTable({
  memberships,
}: MembershipsTableProps) {
  const [{ yearPaid }] = useGetMembershipsUrlParams();

  const data: MembershipColumns[] = memberships.map(membership => {
    const startDate = membership.startDate
      ? new Date(membership.startDate)
      : null;

    return {
      id: membership.id,
      membershipType: membership.membershipType,
      members: membership.members,
      address: membership.address || null,
      startDate,
      hasPaid: !membership.due
        ? startDate && yearPaid < startDate?.getFullYear() ? null : false
        : true,
    };
  });

  return (
    <DataTable
      columns={columns}
      data={data}
    />
  );
}