import {
  useQueryStates,
  createSerializer,
  parseAsIsoDateTime,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

const parsers = {
  joinedFrom: parseAsIsoDateTime.withDefault(new Date(new Date().getFullYear(), 1, 1)),
  joinedTo: parseAsIsoDateTime.withDefault(new Date()),
};

export const useGetMembersByDateUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const getMembersByDateUrlParams = createSearchParamsCache(parsers);

export const serializeGetMembersByDateUrlParams = createSerializer(parsers);