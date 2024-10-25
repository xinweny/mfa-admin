'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';

import { Address } from '@/modules/address/types';
import { MembershipType } from '../../types';
import { PaymentMethod } from '@/modules/due/types';

import { DataTableSortButton } from '@/core/data/components/data-table-sort-button';

import { AddressDisplay } from '@/modules/address/components/address-display';
import { PaidStatusCell } from './paid-status-cell';
import { MembersCell } from './members-cell';
import { MembershipTypeCell } from './membership-type-cell';
import { YearPaidHeader } from './year-paid-header';
import { StatusCell } from './status-cell';
import { MembershipRowDropdownMenu } from './membership-row-dropdown-menu';

export interface MembershipColumns {
  id: string;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
  address: Address | null,
  membershipType: MembershipType;
  startDate: Date;
  due: {
    id: string;
    year: number;
    paymentDate: Date | null;
    amountPaid: number;
    paymentMethod: PaymentMethod;
  } | null;
  isActive: boolean;
}

export const columns: ColumnDef<MembershipColumns>[] = [
  {
    accessorKey: 'membershipType',
    header: 'Type',
    cell: ({ row: { original: { membershipType, id } } }) => (
      <MembershipTypeCell
        id={id}
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
    accessorKey: 'due',
    header: () => <YearPaidHeader />,
    cell: ({ row: { original: { due, startDate } } }) => (
      <PaidStatusCell due={due} startDate={startDate}  />
    ),
  },
  {
    accessorKey: 'isActive',
    header: 'Status',
    cell: ({ row: { original: { isActive } } }) => (
      <StatusCell isActive={isActive}  />
    ),
  },
  {
    id: 'id',
    cell: ({ row: { original: { id } } }) => (
      <MembershipRowDropdownMenu
        membershipId={id}
      />
    ),
  },
];