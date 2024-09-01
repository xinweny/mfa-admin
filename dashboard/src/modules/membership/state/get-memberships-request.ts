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

const parsers = {
  yearPaid: parseAsInteger.withDefault(new Date().getFullYear()),
  hasPaid: parseAsBoolean,
  query: parseAsString,
  membershipType: parseAsStringEnum<MembershipType>(Object.values(MembershipType)),
  sortStartDate: parseAsStringEnum(Object.values(SortOrder)),
  sinceFrom: parseAsIsoDateTime,
  sinceTo: parseAsIsoDateTime,
};

export const useGetMembershipsUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembershipsUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembershipsRequest = createSerializer(parsers);