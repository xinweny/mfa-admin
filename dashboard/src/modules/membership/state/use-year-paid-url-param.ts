import { useQueryState, parseAsInteger } from 'nuqs';

export const useYearPaidUrlParam = () => {
  return useQueryState(
    'yearPaid',
    parseAsInteger
      .withOptions({
        shallow: false,
      })
      .withDefault(new Date().getFullYear())
  );
};