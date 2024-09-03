import {
  MoveUpIcon,
  MoveDownIcon,
  ArrowUpDownIcon,
  LucideIcon,
} from 'lucide-react';

import { SortOrder } from '@/types/sort-order';

import { useSortUrlParam } from '../../state';

interface DataTableSortButtonProps {
  name: string;
  label: string;
}

export function DataTableSortButton({
  name,
  label,
}: DataTableSortButtonProps) {
  const [sort, setSort] = useSortUrlParam(name);

  const SortIcon = sortIcons[sort];

  return (
    <button
      className="flex items-center gap-2"
      onClick={() => {
        switch (sort) {
          case SortOrder.Ascending:
            setSort(SortOrder.Descending);
            break;
          case SortOrder.Descending:
            setSort(SortOrder.Unsorted);
            break;
          default:
            setSort(SortOrder.Ascending);
        }
      }}
    >
      <span>{label}</span>
      <SortIcon size={16} />
    </button>
  );
}

const sortIcons: Record<SortOrder, LucideIcon> = {
  [SortOrder.Ascending]: MoveDownIcon,
  [SortOrder.Descending]: MoveUpIcon,
  [SortOrder.Unsorted]: ArrowUpDownIcon,
};