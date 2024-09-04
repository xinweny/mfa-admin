'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { DateRange } from 'react-day-picker';

import {
  getExchangesSchema,
  GetExchangesSchema,
  ExchangeTypeInputValues,
} from './schema';

import { ExchangeType, exchangeTypeLabels } from '../../types';

import { useGetExchangesUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { TextInputFilter } from '@/core/data/components/text-input-filter';

export function ExchangesTableFilters() {
  const [params, setParams] = useGetExchangesUrlParams();

  const form = useForm<GetExchangesSchema>({
    defaultValues: {
      fromYear: params.fromYear || undefined,
      toYear: params.toYear || undefined,
      exchangeType: exchangeTypeValues.find(e => e.value === params.exchangeType)?.inputValue || ExchangeTypeInputValues.All,
    },
    resolver: zodResolver(getExchangesSchema),
  });

  const handleSubmit = (data: GetExchangesSchema) => {
    const exchangeType = exchangeTypeValues.find(r => r.inputValue === data.exchangeType)?.value;

    setParams({
      query: data.query || null,
      fromYear: data.fromYear || null,
      toYear: data.toYear || null,
      exchangeType: exchangeType !== undefined ? exchangeType : null,
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
          name: 'exchangeType',
          render: ({ field }) => (
            <SelectFilter
              currentValue={field.value as string}
              onChange={field.onChange}
              values={exchangeTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
      ]}
      reset={{
        query: undefined,
        fromYear: undefined,
        toYear: undefined,
        exchangeType: ExchangeTypeInputValues.All,
      }}
    />
  );
}

const exchangeTypeValues = [
  {
    inputValue: ExchangeTypeInputValues.All,
    value: null,
    label: 'All',
  },
  {
    inputValue: ExchangeTypeInputValues.Host,
    value: ExchangeType.Host,
    label: exchangeTypeLabels[ExchangeType.Host],
  },
  {
    inputValue: ExchangeTypeInputValues.Delegate,
    value: ExchangeType.Delegate,
    label: exchangeTypeLabels[ExchangeType.Delegate],
  },
];
