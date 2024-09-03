'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';

import { MembershipType } from '@/modules/membership/types';
import { PaymentMethod } from '../../types';

import { DataTableSortButton } from '@/core/data/components/data-table-sort-button';

import { DueRowDropdownMenu } from './components/due-row-dropdown-menu';
import { MembershipCell } from './components/membership-cell';
import { PaymentMethodCell } from './components/payment-method-cell';

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
    cell: ({ row: { original: { id, membership } } }) => (membership && (
      <MembershipCell
        id={id}
        membershipType={membership.membershipType}
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
    header: 'Amount ($)',
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
    cell: ({ row: { original: { id } } }) => (
      <DueRowDropdownMenu
        dueId={id}
      />
    ),
  },
];