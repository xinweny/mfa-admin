'use client';

import { GetMembershipsResponse } from '../../types';

import { DataTable } from '@/core/data/components/data-table';

import { MembershipColumns, columns } from './columns';

interface MembershipsTableProps {
  memberships: GetMembershipsResponse[];
}

export function MembershipsTable({
  memberships,
}: MembershipsTableProps) {
  const data: MembershipColumns[] = memberships.map(m => {
    return {
      id: m.id,
      membershipType: m.membershipType,
      members: m.members,
      address: m.address,
      startDate: new Date(m.startDate),
      due: m.due
        ? {
          ...m.due,
          paymentDate: m.due.paymentDate ? new Date(m.due.paymentDate) : null,
        }
        : null,
      isActive: m.isActive,
    };
  });

  return (
    <DataTable
      columns={columns}
      data={data}
    />
  );
}