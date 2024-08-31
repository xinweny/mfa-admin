'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';

import { Address } from '@/modules/address/types';
import { MembershipType } from '../../types/membership-type';

import { DataTableSortButton } from '@/modules/data/components/data-table-sort-button';

import { AddressDisplay } from '@/modules/address/components/address-display';
import { PaidStatusCell } from './cells/paid-status-cell';
import { MembersCell } from './cells/members-cell';
import { MembershipTypeCell } from './cells/membership-type-cell';
import { YearPaidFilter } from '../year-paid-filter';

export interface MembershipColumns {
  id: string;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
  address: Address | null,
  membershipType: MembershipType;
  startDate: Date | null;
  hasPaid: boolean | null;
}

export const columns: ColumnDef<MembershipColumns>[] = [
  {
    accessorKey: 'membershipType',
    header: 'Type',
    cell: ({ row: { original: { membershipType } } }) => (
      <MembershipTypeCell
        membershipType={membershipType}
      />
    ),
  },
  {
    accessorKey: 'members',
    header: 'Members',
    cell: ({ row: { original: { members } } }) => <MembersCell members={members} />,
  },
  {
    accessorKey: 'address',
    header: 'Address',
    cell: ({ row: { original: { address } } }) => (
      address == null
        ? null
        : <AddressDisplay address={address} />
    ),
  },
  {
    accessorKey: 'startDate',
    header: () => (
      <DataTableSortButton
        name="sortStartDate"
        label="Since"
      />
    ),
    cell: ({ row: { original: { startDate } } }) => startDate && format(startDate, 'dd/LL/yyyy'),
  },
  {
    accessorKey: 'paidForYear',
    header: () => <YearPaidFilter />,
    cell: ({ row: { original: { hasPaid } } }) => (
      hasPaid === null
        ? null
        : <PaidStatusCell hasPaid={hasPaid} />
    ),
  },
];