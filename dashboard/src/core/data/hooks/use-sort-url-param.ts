import { useQueryState, parseAsNumberLiteral } from 'nuqs';

import { SortOrder } from '@/types/sort-order';

export const useSortUrlParam = (name: string) => {
  return useQueryState(
    name,
    parseAsNumberLiteral(Object.values(SortOrder) as number[])
      .withDefault(SortOrder.Unsorted)
      .withOptions({ shallow: false })
  );
}