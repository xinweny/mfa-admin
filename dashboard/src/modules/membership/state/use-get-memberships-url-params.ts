import {
  parseAsInteger,
  parseAsString,
  parseAsStringEnum,
  useQueryStates,
} from 'nuqs';

import { SortOrder } from '@/types/sort-order';

export const useGetMembershipsUrlParams = () => useQueryStates({
  year: parseAsInteger.withDefault(new Date().getFullYear()),
  query: parseAsString,
  sortStartDate: parseAsStringEnum<SortOrder>(Object.values(SortOrder)),
});