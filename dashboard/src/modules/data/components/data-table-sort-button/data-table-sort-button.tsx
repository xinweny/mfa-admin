import {
  MoveUpIcon,
  MoveDownIcon,
  ArrowUpDownIcon,
  LucideIcon,
} from 'lucide-react';

import { SortOrder } from '@/types/sort-order';

import { useSortUrlParam } from '../../state';

import { Button } from '@/components/ui/button';

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
    <Button
      className="gap-2"
      variant="ghost"
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
    </Button>
  );
}

const sortIcons: Record<SortOrder, LucideIcon> = {
  [SortOrder.Ascending]: MoveDownIcon,
  [SortOrder.Descending]: MoveUpIcon,
  [SortOrder.Unsorted]: ArrowUpDownIcon,
};