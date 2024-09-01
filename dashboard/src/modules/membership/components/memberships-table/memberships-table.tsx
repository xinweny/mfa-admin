'use client';

import { GetMembershipsResponse } from '../../types';

import { DataTable } from '@/modules/data/components/data-table';

import { MembershipColumns, columns } from './columns';

interface MembershipsTableProps {
  memberships: GetMembershipsResponse[];
}

export function MembershipsTable({
  memberships,
}: MembershipsTableProps) {
  const data: MembershipColumns[] = memberships.map(membership => {
    return {
      id: membership.id,
      membershipType: membership.membershipType,
      members: membership.members,
      address: membership.address,
      startDate: new Date(membership.startDate),
      due: membership.due
        ? {
          ...membership.due,
          paymentDate: membership.due.paymentDate ? new Date(membership.due.paymentDate) : null,
        }
        : null,
    };
  });

  return (
    <DataTable
      columns={columns}
      data={data}
    />
  );
}