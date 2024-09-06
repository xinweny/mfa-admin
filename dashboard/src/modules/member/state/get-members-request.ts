import {
  useQueryStates,
  parseAsString,
  parseAsNumberLiteral,
  createSerializer,
  parseAsBoolean,
  parseAsIsoDateTime,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';

import { paginationParsers } from '@/core/data/state';

const parsers = {
  query: parseAsString,
  joinedFrom: parseAsIsoDateTime,
  joinedTo: parseAsIsoDateTime,
  isMississaugaResident: parseAsBoolean,
  sortFirstName: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  sortLastName: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  sortJoinedDate: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  ...paginationParsers,
};

export const useGetMembersUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembersUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembersUrlParams = createSerializer(parsers);