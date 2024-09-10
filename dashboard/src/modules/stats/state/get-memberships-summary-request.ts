import {
  useQueryStates,
  parseAsInteger,
  createSerializer,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

const parsers = {
  dueYear: parseAsInteger.withDefault(new Date().getFullYear()),
};

export const useGetMembershipsSummaryUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembershipsSummaryUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembershipsSummaryUrlParams = createSerializer(parsers);