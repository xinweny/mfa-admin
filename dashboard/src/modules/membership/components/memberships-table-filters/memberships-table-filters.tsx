'use client';

import { useForm } from 'react-hook-form';
import { DateRange } from 'react-day-picker';

import { MembershipType, membershipTypeLabels } from '../../types';

import {
  getMembershipsSchemaResolver,
  GetMembershipsSchema,
  HasPaidInputValues,
  MembershipTypeInputValues,
  IsActiveInputValues,
} from './schema';

import { mfaFoundingYear } from '@/core/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { DateRangeFilter } from '@/core/data/components/date-range-filter';
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
      isActive: params.isActive === null
        ? IsActiveInputValues.All
        : params.isActive ? IsActiveInputValues.Active : IsActiveInputValues.Inactive,
    },
    resolver: getMembershipsSchemaResolver,
  });

  const handleSubmit = (data: GetMembershipsSchema) => {
    const membershipType = membershipTypeValues.find(m => m.inputValue === data.membershipType)?.value;
    const hasPaid = hasPaidValues.find(p => p.inputValue === data.hasPaid)?.value;
    const isActive = isActiveValues.find(a => a.inputValue === data.isActive)?.value;

    setParams({
      query: data.query || null,
      yearPaid: data.yearPaid,
      membershipType: membershipType !== undefined ? membershipType : null,
      hasPaid: hasPaid !== undefined ? hasPaid : null,
      sinceFrom: data.startDateRange.from || null,
      sinceTo: data.startDateRange.to || null,
      isActive: isActive !== undefined ? isActive : null,
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
              value={field.value as string}
              onChange={field.onChange}
              options={membershipTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
        {
          label: 'Date Range',
          name: 'startDateRange',
          render: ({ field }) => (
            <DateRangeFilter
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
              value={field.value as string}
              onChange={field.onChange}
              options={hasPaidValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
        {
          label: 'Activity',
          name: 'isActive',
          render: ({ field }) => (
            <SelectFilter
              value={field.value as string}
              onChange={field.onChange}
              options={isActiveValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
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
        isActive: IsActiveInputValues.All,
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

const isActiveValues = [
  {
    inputValue: IsActiveInputValues.All,
    value: null,
    label: 'All',
  },
  {
    inputValue: IsActiveInputValues.Active,
    value: true,
    label: 'Active',
  },
  {
    inputValue: IsActiveInputValues.Inactive,
    value: false,
    label: 'Inactive',
  },
];

