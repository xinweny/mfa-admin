import {
  useQueryStates,
  parseAsNumberLiteral,
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
  paymentMethods: parseAsArrayOf(parseAsNumberLiteral(Object.values(PaymentMethod) as number[])),
  membershipType: parseAsNumberLiteral(Object.values(MembershipType) as number[]),
  dateFrom: parseAsIsoDateTime,
  dateTo: parseAsIsoDateTime,
  sortYear: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
  sortPaymentDate: parseAsNumberLiteral(Object.values(SortOrder) as number[]),
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