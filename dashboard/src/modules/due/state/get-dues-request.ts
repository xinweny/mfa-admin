import {
  useQueryStates,
  parseAsStringEnum,
  createSerializer,
  parseAsInteger,
  parseAsArrayOf,
  parseAsIsoDateTime,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';
import { PaymentMethod } from '../types';
import { MembershipType } from '@/modules/membership/types';

import { paginationParsers } from '@/core/data/state';

const parsers = {
  year: parseAsInteger.withDefault(new Date().getFullYear()),
  paymentMethods: parseAsArrayOf(parseAsStringEnum(Object.values(PaymentMethod))),
  membershipType: parseAsStringEnum(Object.values(MembershipType)),
  dateFrom: parseAsIsoDateTime,
  dateTo: parseAsIsoDateTime,
  sortYear: parseAsStringEnum(Object.values(SortOrder)),
  sortPaymentDate: parseAsStringEnum(Object.values(SortOrder)),
  ...paginationParsers,
};

export const useGetDuesUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getDuesUrlParams = createSearchParamsCache(parsers);

export const serializeGetDuesUrlParams = createSerializer(parsers);