import {
  useQueryStates,
  createSerializer,
  parseAsIsoDateTime,
} from 'nuqs';
import { subDays } from 'date-fns';

import { createSearchParamsCache } from 'nuqs/server';

const parsers = {
  joinedFrom: parseAsIsoDateTime.withDefault(subDays(new Date(), 30)),
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