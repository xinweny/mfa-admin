'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';
import parsePhoneNumber from 'libphonenumber-js';

import { Address } from '@/modules/address/types';
import { MembershipType } from '@/modules/membership/types';

import { DataTableSortButton } from '@/core/data/components/data-table-sort-button';

import { MemberRowDropdownMenu } from './components/member-row-dropdown-menu';
import { MembershipTypeCell } from './components/membership-type-cell';
import { MississaugaResidentCell } from './components/mississauga-resident-cell';

export interface MemberColumns {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string | null;
  address: Address | null;
  membership: {
    id: string;
    membershipType: MembershipType;
  };
  joinedDate: Date | null;
}

export const columns: ColumnDef<MemberColumns>[] = [
  {
    accessorKey: 'firstName',
    header: () => (
      <DataTableSortButton
        name="sortFirstName"
        label="First Name"
      />
    ),
  },
  {
    accessorKey: 'lastName',
    header: () => (
      <DataTableSortButton
        name="sortLastName"
        label="Last Name"
      />
    ),
  },
  {
    accessorKey: 'email',
    header: 'Email',
  },
  {
    accessorKey: 'phoneNumber',
    header: 'Phone',
    cell: ({ row: { original: { phoneNumber } } }) => phoneNumber
      ? parsePhoneNumber(`+1${phoneNumber}`)?.formatNational()
      : null
  },
  {
    accessorKey: 'membershipType',
    header: 'Membership Type',
    cell: ({ row: { original: { membership: { membershipType, id } } } }) => (
      <MembershipTypeCell
        id={id}
        membershipType={membershipType}
      />
    ),
  },
  {
    accessorKey: 'address',
    header: 'Mississauga Ties',
    cell: ({ row: { original: { address } } }) => (
      <MississaugaResidentCell
        city={address?.city}
      />
    )
  },
  {
    accessorKey: 'joinedDate',
    header: () => (
      <DataTableSortButton
        name="sortJoinedDate"
        label="Joined"
      />
    ),
    cell: ({ row: { original: { joinedDate } } }) => joinedDate && format(joinedDate, 'dd/LL/yyyy'),
  },
  {
    id: 'id',
    cell: ({ row: { original: { id } } }) => (
      <MemberRowDropdownMenu
        id={id}
      />
    ),
  },
];