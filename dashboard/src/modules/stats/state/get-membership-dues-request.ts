import {
  useQueryStates,
  parseAsInteger,
  createSerializer,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

const parsers = {
  dueYear: parseAsInteger.withDefault(new Date().getFullYear()),
};

export const useGetMembershipDuesUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembershipDuesUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembershipDuesUrlParams = createSerializer(parsers);