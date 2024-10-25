'use client';

import { GetMembersResponse } from '../../types';

import { DataTable } from '@/core/data/components/data-table';

import { MemberColumns, columns } from './columns';

interface MembersTableProps {
  members: GetMembersResponse[];
}

export function MembersTable({
  members,
}: MembersTableProps) {
  const data: MemberColumns[] = members.map(m => {
    return {
      id: m.id,
      firstName: m.firstName,
      lastName: m.lastName,
      email: m.email,
      phoneNumber: m.phoneNumber,
      membership: {
        id: m.membershipId,
        membershipType: m.membership.membershipType,
        isActive: m.membership.isActive,
      },
      address: m.membership.address,
      joinedDate: m.joinedDate ? new Date(m.joinedDate) : null,
    };
  });

  return (
    <DataTable
      columns={columns}
      data={data}
    />
  );
}