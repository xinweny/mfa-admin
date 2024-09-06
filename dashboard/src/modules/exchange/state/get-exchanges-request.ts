import {
  useQueryStates,
  parseAsNumberLiteral,
  parseAsString,
  createSerializer,
  parseAsInteger,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';
import { ExchangeType } from '../types';

import { paginationParsers } from '@/core/data/state';


const parsers = {
  query: parseAsString,
  year: parseAsInteger,
  exchangeType: parseAsNumberLiteral(Object.values(ExchangeType) as number[]),
  sortYear: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  ...paginationParsers,
};

export const useGetExchangesUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getExchangesUrlParams = createSearchParamsCache(parsers);

export const serializeGetExchangesUrlParams = createSerializer(parsers);