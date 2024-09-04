'use client';

import { GetExchangesResponse } from '../../types';

import { DataTable } from '@/core/data/components/data-table';

import { ExchangeColumns, columns } from './columns';

interface ExchangesTableProps {
  exchanges: GetExchangesResponse[];
}

export function ExchangesTable({
  exchanges,
}: ExchangesTableProps) {
  const data: ExchangeColumns[] = exchanges.map(e => {
    return {
      id: e.id,
      year: e.year,
      exchangeType: e.exchangeType,
      member: e.member
        ? {
          id: e.member.id,
          firstName: e.member.firstName,
          lastName: e.member.lastName,
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