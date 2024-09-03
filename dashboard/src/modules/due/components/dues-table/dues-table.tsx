'use client';

import { GetDuesResponse } from '../../types';

import { DataTable } from '@/core/data/components/data-table';

import { DueColumns, columns } from './columns';

interface DuesTableProps {
  dues: GetDuesResponse[];
}

export function DuesTable({
  dues,
}: DuesTableProps) {
  const data: DueColumns[] = dues.map(d => {
    return {
      id: d.id,
      year: d.year,
      amountPaid: d.amountPaid,
      paymentMethod: d.paymentMethod,
      paymentDate: d.paymentDate ? new Date(d.paymentDate) : null,
      membershipId: d.membershipId,
      membership: d.membership
        ? {
          id: d.membership.id,
          membershipType: d.membership.membershipType,
          members: d.membership.members.map(m => ({
            id: m.id,
            firstName: m.firstName,
            lastName: m.lastName,
          })),
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