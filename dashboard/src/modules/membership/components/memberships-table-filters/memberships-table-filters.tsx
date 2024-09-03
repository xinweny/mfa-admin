'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { DateRange } from 'react-day-picker';

import { MembershipType, membershipTypeLabels } from '../../types';

import {
  getMembershipsSchema,
  GetMembershipsSchema,
  HasPaidInputValues,
  MembershipTypeInputValues,
} from './schema';

import { mfaFoundingYear } from '@/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { PopoverDateRangeFilter } from '@/core/data/components/popover-date-range-filter';
import { NumberInputFilter } from '@/core/data/components/number-input-filter';
import { TextInputFilter } from '@/core/data/components/text-input-filter';

export function MembershipsTableFilters() {
  const [params, setParams] = useGetMembershipsUrlParams();

  const form = useForm<GetMembershipsSchema>({
    defaultValues: {
      query: params.query || '',
      yearPaid: params.yearPaid,
      membershipType: membershipTypeValues
        .find(m => m.value === params.membershipType)?.inputValue || MembershipTypeInputValues.All,
      hasPaid: params.hasPaid === null
        ? HasPaidInputValues.All
        : params.hasPaid ? HasPaidInputValues.Paid : HasPaidInputValues.NotPaid,
      startDateRange: {
        from: params.sinceFrom || undefined,
        to: params.sinceFrom || undefined,
      },
    },
    resolver: zodResolver(getMembershipsSchema),
  });

  const handleSubmit = (data: GetMembershipsSchema) => {
    const membershipType = membershipTypeValues.find(m => m.inputValue === data.membershipType)?.value;
    const hasPaid = hasPaidValues.find(p => p.inputValue === data.hasPaid)?.value;

    setParams({
      query: data.query || null,
      yearPaid: data.yearPaid,
      membershipType: membershipType || null,
      hasPaid: hasPaid !== undefined ? hasPaid : null,
      sinceFrom: data.startDateRange.from || null,
      sinceTo: data.startDateRange.to || null,
    });
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
            <TextInputFilter
              placeholder="Search names"
              {...field}
              value={field.value as string}
            />
          ),
        },
        {
          label: 'Type',
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
          name: 'startDateRange',
          render: ({ field }) => (
            <PopoverDateRangeFilter
              date={field.value as DateRange}
              onChange={field.onChange}
            />
          ),
        },
        {
          label: 'Year Paid',
          name: 'yearPaid',
          render: ({ field }) => (
            <NumberInputFilter
              min={mfaFoundingYear}
              {...field}
              value={field.value as number}
            />
          ),
        },
        {
          label: 'Paid Status',
          name: 'hasPaid',
          render: ({ field }) => (
            <SelectFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={hasPaidValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
      ]}
      reset={{
        query: '',
        yearPaid: new Date().getFullYear(),
        membershipType: MembershipTypeInputValues.All,
        hasPaid: HasPaidInputValues.All,
        startDateRange: {},
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
    label: membershipTypeLabels[MembershipType.Single],
  },
  {
    inputValue: MembershipTypeInputValues.Family,
    value: MembershipType.Family,
    label: membershipTypeLabels[MembershipType.Family],
  },
  {
    inputValue: MembershipTypeInputValues.Honorary,
    value: MembershipType.Honorary,
    label: membershipTypeLabels[MembershipType.Honorary],
  },
];

const hasPaidValues = [
  {
    inputValue: HasPaidInputValues.All,
    value: null,
    label: 'All',
  },
  {
    inputValue: HasPaidInputValues.Paid,
    value: true,
    label: 'Paid',
  },
  {
    inputValue: HasPaidInputValues.NotPaid,
    value: false,
    label: 'Unpaid',
  },
];

