import {
  useQueryStates,
  parseAsInteger,
  createSerializer,
} from 'nuqs';
import { createSearchParamsCache } from 'nuqs/server';

export const paginationParsers = {
  page: parseAsInteger.withDefault(1),
  limit: parseAsInteger,
};

export const usePaginationUrlParams = () => {
  return useQueryStates(
    paginationParsers,
    { shallow: false }
  );
};

export const paginationUrlParams = createSearchParamsCache(paginationParsers);

export const serializePaginationParams = createSerializer(paginationParsers);