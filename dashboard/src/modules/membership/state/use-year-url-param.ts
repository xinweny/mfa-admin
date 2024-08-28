import { useQueryState, parseAsInteger } from 'nuqs';

export const useYearUrlParam = () => {
  return useQueryState(
    'year',
    parseAsInteger
      .withOptions({
        shallow: false,
      })
      .withDefault(new Date().getFullYear())
  );
};