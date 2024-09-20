'use client';

import { ColumnDef } from '@tanstack/react-table';

import { DataTableSortButton } from '@/core/data/components/data-table-sort-button';

import { ExchangeType } from '../../types';

import { ExchangeRowDropdownMenu } from './exchange-row-dropdown-menu';
import { ExchangeTypeCell } from './exchange-type-cell';
import { MemberCell } from './member-cell';

export interface ExchangeColumns {
  id: string;
  year: number;
  exchangeType: ExchangeType;
  member: {
    id: string;
      firstName: string;
      lastName: string;
  } | null;
}

export const columns: ColumnDef<ExchangeColumns>[] = [
  {
    accessorKey: 'member',
    header: 'Member',
    cell: ({ row: { original: { member } } }) => (
      member && <MemberCell member={member} />
    )
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
    accessorKey: 'exchangeType',
    header: 'Exchange Type',
    cell: ({ row: { original: { exchangeType } } }) => (
      <ExchangeTypeCell
        exchangeType={exchangeType}
      />
    ),
  },
  {
    id: 'id',
    cell: ({ row: { original: { id } } }) => (
      <ExchangeRowDropdownMenu
        exchangeId={id}
      />
    ),
  },
];