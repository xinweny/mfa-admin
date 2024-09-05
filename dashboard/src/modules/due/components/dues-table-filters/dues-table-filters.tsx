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

import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';
import { PaymentMethod, paymentMethodLabels } from '../../types';

import { useGetDuesUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { DateRangeFilter } from '@/core/data/components/date-range-filter';
import { NumberInputFilter } from '@/core/data/components/number-input-filter';
import { MultiSelectFilter } from '@/core/data/components/multi-select-filter';

export function DuesTableFilters() {
  const [params, setParams] = useGetDuesUrlParams();

  const form = useForm<GetDuesSchema>({
    defaultValues: {
      year: params.year,
      membershipType: membershipTypeValues.find(m => m.value === params.membershipType)?.inputValue || MembershipTypeInputValues.All,
      paymentMethods: params.paymentMethods || [],
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
      paymentMethods: data.paymentMethods.length === 0 ? null : data.paymentMethods,
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
              value={field.value as string}
              onChange={field.onChange}
              options={membershipTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
        {
          label: 'Methods',
          name: 'paymentMethods',
          render: ({ field }) => (
            <MultiSelectFilter
              options={paymentMethodOptions}
              values={field.value as string[]}
              onChange={field.onChange}
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
    label: membershipTypeLabels[MembershipType.Single],
  },
  {
    inputValue: MembershipTypeInputValues.Family,
    value: MembershipType.Family,
    label: membershipTypeLabels[MembershipType.Family],
  },
];

const paymentMethodOptions = [
  {
    value: PaymentMethod.Cash,
    label: paymentMethodLabels[PaymentMethod.Cash],
  },
  {
    value: PaymentMethod.EFT,
    label: paymentMethodLabels[PaymentMethod.EFT],
  },
  {
    value: PaymentMethod.Cheque,
    label: paymentMethodLabels[PaymentMethod.Cheque],
  },
];
