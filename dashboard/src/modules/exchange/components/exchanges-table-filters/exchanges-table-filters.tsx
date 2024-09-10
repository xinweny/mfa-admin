'use client';

import { useForm } from 'react-hook-form';

import {
  GetExchangesSchema,
  ExchangeTypeInputValues,
  getExchangesSchemaResolver,
} from './schema';

import { ExchangeType, exchangeTypeLabels } from '../../types';

import { useGetExchangesUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/core/data/components/data-table-filters-form';
import { SelectFilter } from '@/core/data/components/select-filter';
import { TextInputFilter } from '@/core/data/components/text-input-filter';
import { NumberInputFilter } from '@/core/data/components/number-input-filter';

export function ExchangesTableFilters() {
  const [params, setParams] = useGetExchangesUrlParams();

  const form = useForm<GetExchangesSchema>({
    defaultValues: {
      year: params.year || undefined,
      exchangeType: exchangeTypeValues.find(e => e.value === params.exchangeType)?.inputValue || ExchangeTypeInputValues.All,
    },
    resolver: getExchangesSchemaResolver,
  });

  const handleSubmit = (data: GetExchangesSchema) => {
    const exchangeType = exchangeTypeValues.find(r => r.inputValue === data.exchangeType)?.value;

    setParams({
      query: data.query || null,
      year: data.year || null,
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
          label: 'Year',
          name: 'year',
          render: ({ field }) => (
            <NumberInputFilter
              {...field}
              value={field.value as number}
            />
          ),
        },
        {
          label: 'Type',
          name: 'exchangeType',
          render: ({ field }) => (
            <SelectFilter
              value={field.value as string}
              onChange={field.onChange}
              options={exchangeTypeValues.map(({ inputValue, label }) => ({ value: inputValue, label }))}
            />
          ),
        },
      ]}
      reset={{
        query: undefined,
        year: undefined,
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
