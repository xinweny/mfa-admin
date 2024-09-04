import {
  useQueryStates,
  parseAsStringEnum,
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
  exchangeType: parseAsStringEnum(Object.values(ExchangeType)),
  sortYear: parseAsStringEnum(Object.values(SortOrder)),
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