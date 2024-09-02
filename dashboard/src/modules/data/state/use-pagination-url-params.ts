import {
  useQueryStates,
  parseAsInteger,
  createSerializer,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

const parsers = {
  page: parseAsInteger.withDefault(1),
  limit: parseAsInteger,
};

export const usePaginationUrlParams = () => {
  return useQueryStates(
    parsers,
    { shallow: false }
  );
};

export const paginationUrlParams = createSearchParamsCache(parsers);

export const serializePaginationParams = createSerializer(parsers);