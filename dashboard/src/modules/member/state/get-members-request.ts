import {
  useQueryStates,
  parseAsString,
  parseAsStringEnum,
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
  sortFirstName: parseAsStringEnum(Object.values(SortOrder)),
  sortLastName: parseAsStringEnum(Object.values(SortOrder)),
  sortJoinedDate: parseAsStringEnum(Object.values(SortOrder)),
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