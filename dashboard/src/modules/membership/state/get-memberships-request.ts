import {
  useQueryStates,
  parseAsInteger,
  parseAsString,
  parseAsStringEnum,
  createSerializer,
} from 'nuqs';

import { SortOrder } from '@/types';

export const useGetMembershipsUrlParams = () => {
  return useQueryStates(
    {
      query: parseAsString,
      yearPaid: parseAsInteger
        .withDefault(new Date().getFullYear()),
    },
    { shallow: false }
  );
};

export const getMembershipsSerializer = createSerializer({
  yearPaid: parseAsInteger,
  query: parseAsString,
  sortStartDate: parseAsStringEnum(Object.values(SortOrder)),
});