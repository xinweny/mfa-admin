import {
  useQueryStates,
  parseAsInteger,
  parseAsString,
  createSerializer,
  parseAsBoolean,
  parseAsIsoDateTime,
  parseAsNumberLiteral,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';
import { MembershipType } from '../types';

import { paginationParsers } from '@/core/data/hooks';

const parsers = {
  yearPaid: parseAsInteger.withDefault(new Date().getFullYear()),
  hasPaid: parseAsBoolean,
  query: parseAsString,
  membershipType: parseAsNumberLiteral(Object.values(MembershipType) as number[]),
  sortStartDate: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  sinceFrom: parseAsIsoDateTime,
  sinceTo: parseAsIsoDateTime,
  isActive: parseAsBoolean,
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