import {
  useQueryStates,
  parseAsInteger,
  parseAsString,
  parseAsStringEnum,
  createSerializer,
} from 'nuqs';

import { SortOrder } from '@/types';
import { MembershipType } from '../types';

const parsers = {
  yearPaid: parseAsInteger.withDefault(new Date().getFullYear()),
  query: parseAsString,
  membershipType: parseAsStringEnum<MembershipType>(Object.values(MembershipType)),
  sortStartDate: parseAsStringEnum(Object.values(SortOrder)),
};

export const useGetMembershipsUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembershipsSerializer = createSerializer(parsers);