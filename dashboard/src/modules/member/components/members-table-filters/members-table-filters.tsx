'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { DateRange } from 'react-day-picker';

import {
  getMembersSchema,
  GetMembersSchema,
  IsMississaugaResidentInputValues,
} from './schema';

import { useGetMembersUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { PopoverDateRangeFilter } from '@/core/data/components/popover-date-range-filter';
import { TextInputFilter } from '@/core/data/components/text-input-filter';

export function MembershipsTableFilters() {
  const [params, setParams] = useGetMembersUrlParams();

  const form = useForm<GetMembersSchema>({
    defaultValues: {
      query: params.query || '',
      isMississaugaResident: params.isMississaugaResident === null
        ? IsMississaugaResidentInputValues.All
        : params.isMississaugaResident
          ? IsMississaugaResidentInputValues.Yes
          : IsMississaugaResidentInputValues.No,
      joinedDateRange: {
        from: params.joinedFrom || undefined,
        to: params.joinedTo || undefined,
      },
    },
    resolver: zodResolver(getMembersSchema),
  });

  const handleSubmit = (data: GetMembersSchema) => {
    const isMississaugaResident = isMississaugaResidentValues.find(r => r.inputValue === data.isMississaugaResident)?.value;

    setParams({
      query: data.query || null,
      isMississaugaResident: isMississaugaResident !== undefined ? isMississaugaResident : null,
      joinedFrom: data.joinedDateRange.from || null,
      joinedTo: data.joinedDateRange.to || null,
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
          label: 'Date Range',
          name: 'joinedDateRange',
          render: ({ field }) => (
            <PopoverDateRangeFilter
              date={field.value as DateRange}
              onChange={field.onChange}
            />
          ),
        },
        {
          label: 'Mississauga Ties',
          name: 'isMississaugaResident',
          render: ({ field }) => (
            <SelectFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={isMississaugaResidentValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
      ]}
      reset={{
        query: '',
        isMississaugaResident: IsMississaugaResidentInputValues.All,
        joinedDateRange: {},
      }}
    />
  );
}

const isMississaugaResidentValues = [
  {
    inputValue: IsMississaugaResidentInputValues.All,
    value: null,
    label: 'All',
  },
  {
    inputValue: IsMississaugaResidentInputValues.Yes,
    value: true,
    label: 'Yes',
  },
  {
    inputValue: IsMississaugaResidentInputValues.No,
    value: false,
    label: 'No',
  },
];

