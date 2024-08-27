'use client';

import { ColumnDef } from '@tanstack/react-table';
import { format } from 'date-fns';
import Link from 'next/link';

import { MembershipColumns } from '../../types';

import { provinceLabels } from '@/modules/address/constants';
import { membershipTypeLabels } from '../../constants';

import { Badge } from '@/components/ui/badge';

export const columns: ColumnDef<MembershipColumns>[] = [
  {
    accessorKey: 'members',
    header: 'Members',
    cell: ({ row }) => (
      <ul className="flex-col">
        {row.original.members
          .map(member => (
            <li key={member.id} className="text-medium">
              <Link href={`/dashboard/members/${member.id}`}>
                {`${member.firstName} ${member.lastName.toUpperCase()}`}
              </Link>
            </li>
          ))}
      </ul>
    ),
  },
  {
    accessorKey: 'address',
    header: 'Address',
    cell: ({ row }) => {
      const address = row.original.address;

      if (!address) return null;

      return (
        <span className="flex flex-col">
          <span>{address.line1}</span>
          <span>{address.line2}</span>
          <span>{address.city}</span>
          <span>{`${provinceLabels[address.province]} ${address.postalCode}`}</span>
        </span>
      );
    },
  },
  {
    accessorKey: 'membershipType',
    header: 'Type',
    cell: ({ row }) => (
      <Badge variant="outline">
        {membershipTypeLabels[row.original.membershipType]}
      </Badge>
    ),
  },
  {
    accessorKey: 'startDate',
    header: 'Since',
    cell: ({ row }) => row.original.startDate && format(row.original.startDate, 'dd/LL/yyyy'),
  },
  {
    accessorKey: 'paidForYear',
    header: 'Paid',
    cell: ({ row }) => {      
      return row.original.paidForYear == null
        ? null
        : (
        <Badge
          variant={row.original.paidForYear
            ? 'default'
            : 'destructive'
          }
        >
          {row.original.paidForYear
            ? 'Paid'
            : 'Not Paid'
          }
        </Badge>
      );
    },
  }
];