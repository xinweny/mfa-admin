import {
  useQueryStates,
  parseAsStringEnum,
  createSerializer,
  parseAsInteger,
  parseAsArrayOf,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

import { SortOrder } from '@/types';
import { PaymentMethod } from '../types';
import { MembershipType } from '@/modules/membership/types';

import { paginationParsers } from '@/core/data/state';


const parsers = {
  year: parseAsInteger.withDefault(new Date().getFullYear()),
  paymentMethods: parseAsArrayOf(parseAsStringEnum(Object.values(PaymentMethod))).withDefault([]),
  sortPaymentDate: parseAsStringEnum(Object.values(SortOrder)),
  membershipType: parseAsStringEnum(Object.values(MembershipType)),
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