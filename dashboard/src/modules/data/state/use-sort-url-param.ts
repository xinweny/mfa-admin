import { useQueryState, parseAsStringEnum } from 'nuqs';

import { SortOrder } from '@/types/sort-order';

export const useSortUrlParam = (name: string) => {
  return useQueryState(
    name,
    parseAsStringEnum(Object.values(SortOrder))
      .withDefault(SortOrder.Unsorted)
      .withOptions({ shallow: false })
  );
}