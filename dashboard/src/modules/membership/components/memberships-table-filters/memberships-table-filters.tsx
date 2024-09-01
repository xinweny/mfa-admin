'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { MembershipType, membershipTypeLabels } from '../../types';

import {
  getMembershipsSchema,
  GetMembershipsSchema,
  HasPaidInputValues,
  MembershipTypeInputValues,
} from './schema';

import { mfaFoundingYear } from '@/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/modules/data/components/data-table-filters-form';
import { Input } from '@/components/ui/input';
import { PopoverRadioFilter } from '@/modules/data/components/popover-radio-filter';

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
            <Input
              placeholder="Search names"
              {...field}
            />
          ),
        },
        {
          label: 'Membership Types',
          name: 'membershipType',
          render: ({ field }) => (
            <PopoverRadioFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={membershipTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
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
        {
          label: 'Paid Status',
          name: 'hasPaid',
          render: ({ field }) => (
            <PopoverRadioFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={hasPaidValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        }
      ]}
      reset={{
        query: '',
        yearPaid: new Date().getFullYear(),
        membershipType: MembershipTypeInputValues.All,
        hasPaid: HasPaidInputValues.All,
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
    label: 'Not Paid',
  },
];

