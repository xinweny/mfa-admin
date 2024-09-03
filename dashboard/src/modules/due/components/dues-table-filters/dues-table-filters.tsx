'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { DateRange } from 'react-day-picker';

import {
  getDuesSchema,
  GetDuesSchema,
  MembershipTypeInputValues,
} from './schema';

import { mfaFoundingYear } from '@/core/constants';

import { MembershipType } from '@/modules/membership/types';

import { useGetDuesUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { DateRangeFilter } from '@/core/data/components/date-range-filter';
import { NumberInputFilter } from '@/core/data/components/number-input-filter';

export function DuesTableFilters() {
  const [params, setParams] = useGetDuesUrlParams();

  const form = useForm<GetDuesSchema>({
    defaultValues: {
      year: params.year,
      membershipType: membershipTypeValues.find(m => m.value === params.membershipType)?.inputValue || MembershipTypeInputValues.All,
      paymentDateRange: {
        from: params.dateFrom || undefined,
        to: params.dateTo || undefined,
      },
    },
    resolver: zodResolver(getDuesSchema),
  });

  const handleSubmit = (data: GetDuesSchema) => {
    const membershipType = membershipTypeValues.find(r => r.inputValue === data.membershipType)?.value;

    setParams({
      year: data.year,
      membershipType: membershipType !== undefined ? membershipType : null,
      dateFrom: data.paymentDateRange.from || null,
      dateTo: data.paymentDateRange.to || null,
    });
  };

  return (
    <DataTableFiltersForm
      form={form}
      onSubmit={handleSubmit}
      filters={[
        {
          label: 'Year',
          name: 'year',
          render: ({ field }) => (
            <NumberInputFilter
              min={mfaFoundingYear}
              {...field}
              value={field.value as number}
            />
          ),
        },
        {
          label: 'Membership Type',
          name: 'membershipType',
          render: ({ field }) => (
            <SelectFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={membershipTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
        {
          label: 'Date Range',
          name: 'paymentDateRange',
          render: ({ field }) => (
            <DateRangeFilter
              date={field.value as DateRange}
              onChange={field.onChange}
            />
          ),
        },
      ]}
      reset={{
        year: new Date().getFullYear(),
        paymentMethods: [],
        membershipType: MembershipTypeInputValues.All,
        paymentDateRange: {},
      }}
    />
  );
}

const membershipTypeValues = [
  {
    inputValue: MembershipTypeInputValues.All,
    value: null,
    label: 'All',
  },
  {
    inputValue: MembershipTypeInputValues.Single,
    value: MembershipType.Single,
    label: 'Single',
  },
  {
    inputValue: MembershipTypeInputValues.Family,
    value: MembershipType.Family,
    label: 'Family',
  },
];

