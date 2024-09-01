'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { MembershipType, membershipTypeLabels } from '../../types';

import {
  getMembershipsSchema,
  GetMembershipsSchema,
  MembershipTypeValues,
} from './schema';

import { mfaFoundingYear } from '@/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/modules/data/components/data-table-filters-form';
import { Input } from '@/components/ui/input';
import { PopoverRadio } from '@/modules/data/components/popover-radio';

export function MembershipsTableFilters() {
  const [params, setParams] = useGetMembershipsUrlParams();

  const form = useForm<GetMembershipsSchema>({
    defaultValues: {
      query: params.query || '',
      yearPaid: params.yearPaid,
      membershipType: membershipTypeValues
        .find(m => m.type === params.membershipType)?.value || MembershipTypeValues.All,
    },
    resolver: zodResolver(getMembershipsSchema),
  });

  const handleSubmit = async (data: GetMembershipsSchema) => {
    await setParams({
      query: data.query || null,
      yearPaid: data.yearPaid,
      membershipType: membershipTypeValues.find(m => m.value === data.membershipType)?.type || null,
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
          label: 'Membership Types',
          name: 'membershipType',
          render: ({ field }) => (
            <PopoverRadio
              currentValue={field.value as string}
              onChange={field.onChange}
              values={membershipTypeValues.map(({ value, label }) => ({ value, label }))}
            />
          ),
        }
      ]}
      reset={{
        query: '',
        yearPaid: new Date().getFullYear(),
        membershipType: MembershipTypeValues.All,
      }}
    />
  );
}

const membershipTypeValues = [
  {
    value: MembershipTypeValues.All,
    type: null,
    label: 'All',
  },
  {
    value: MembershipTypeValues.Single,
    type: MembershipType.Single,
    label: membershipTypeLabels[MembershipType.Single],
  },
  {
    value: MembershipTypeValues.Family,
    type: MembershipType.Family,
    label: membershipTypeLabels[MembershipType.Family],
  },
  {
    value: MembershipTypeValues.Honorary,
    type: MembershipType.Honorary,
    label: membershipTypeLabels[MembershipType.Honorary],
  },
];

