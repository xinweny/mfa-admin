import {
  useQueryStates,
  parseAsInteger,
  parseAsString,
  parseAsStringEnum,
  createSerializer,
  parseAsBoolean,
  parseAsIsoDateTime,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';
import { MembershipType } from '../types';

import { paginationParsers } from '@/core/data/state';

const parsers = {
  yearPaid: parseAsInteger.withDefault(new Date().getFullYear()),
  hasPaid: parseAsBoolean,
  query: parseAsString,
  membershipType: parseAsStringEnum<MembershipType>(Object.values(MembershipType)),
  sortStartDate: parseAsStringEnum(Object.values(SortOrder)),
  sinceFrom: parseAsIsoDateTime,
  sinceTo: parseAsIsoDateTime,
  ...paginationParsers,
};

export const useGetMembershipsUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembershipsUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembershipsUrlParams = createSerializer(parsers);