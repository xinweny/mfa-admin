'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { getMembershipsSchema, GetMembershipsSchema } from './schema';

import { mfaFoundingYear } from '@/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/modules/data/components/data-table-filters-form';
import { Input } from '@/components/ui/input';

export function MembershipsTableFilters() {
  const [params, setParams] = useGetMembershipsUrlParams();

  const form = useForm<GetMembershipsSchema>({
    defaultValues: {
      query: params.query || undefined,
      yearPaid: params.yearPaid,
    },
    resolver: zodResolver(getMembershipsSchema),
  });

  const handleSubmit = async (data: GetMembershipsSchema) => {
    await setParams(data);
  };

  return (
    <DataTableFiltersForm
      form={form}
      onSubmit={handleSubmit}
      filters={[
        {
          label: 'Search',
          name: 'query',
          render: ({ field }) => (
            <Input
              placeholder="Search names"
              {...field}
            />
          ),
        },
        {
          label: 'Year Paid',
          name: 'yearPaid',
          render: ({ field }) => (
            <Input
              type="number"
              min={mfaFoundingYear}
              {...field}
            />
          ),
        },
      ]}
      reset={{
        query: '',
        yearPaid: new Date().getFullYear(),
      }}
    />
  );
}