'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';

import { MembershipType } from '@/modules/membership/types';
import { PaymentMethod } from '../../types';

import { DataTableSortButton } from '@/core/data/components/data-table-sort-button';

import { DueRowDropdownMenu } from './due-row-dropdown-menu';
import { MembersCell } from './members-cell';
import { PaymentMethodCell } from './payment-method-cell';
import { MembershipTypeCell } from './membership-type-cell';

export interface DueColumns {
  id: string;
  year: number;
  amountPaid: number;
  paymentMethod: PaymentMethod;
  paymentDate: Date | null;
  membershipId: string;
  membership: {
    id: string;
    membershipType: MembershipType;
    members: {
      id: string;
      firstName: string;
      lastName: string;
    }[];
  } | null;
}

export const columns: ColumnDef<DueColumns>[] = [
  {
    accessorKey: 'membership',
    header: 'Membership',
    cell: ({ row: { original: { membership } } }) => (membership && (
      <MembershipTypeCell
        membershipType={membership.membershipType}
      />
    )),
  },
  {
    accessorKey: 'members',
    header: 'Members',
    cell: ({ row: { original: { id, membership } } }) => (membership && (
      <MembersCell
        id={id}
        members={membership.members}
      />
    )),
  },
  {
    accessorKey: 'year',
    header: () => (
      <DataTableSortButton
        name="sortYear"
        label="Year"
      />
    ),
  },
  {
    accessorKey: 'amountPaid',
    header: 'Amount',
    cell: ({ row: { original: { amountPaid } } }) => (
      <span>{`$${amountPaid}.00`}</span>
    )
  },
  {
    accessorKey: 'paymentMethod',
    header: 'Method',
    cell: ({ row: { original: { paymentMethod } } }) => (
      <PaymentMethodCell
        paymentMethod={paymentMethod}
      />
    ),
  },
  {
    accessorKey: 'paymentDate',
    header: () => (
      <DataTableSortButton
        name="sortPaymentDate"
        label="Payment Date"
      />
    ),
    cell: ({ row: { original: { paymentDate } } }) => paymentDate && format(paymentDate, 'dd/LL/yyyy'),
  },
  {
    id: 'id',
    cell: ({ row: { original: { id, membershipId } } }) => (
      <DueRowDropdownMenu
        dueId={id}
        membershipId={membershipId}
      />
    ),
  },
];