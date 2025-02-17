'use client';

import { usePaginationUrlParams } from '@/core/data/hooks';

import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from '@/components/ui/select';

export function PaginationLimitSelect() {
  const [{ limit }, setParams] = usePaginationUrlParams(); 

  return (
    <div className="flex items-center gap-2 place-self-start">
      <Select
        onValueChange={(value: string) => {
          setParams({
            page: null,
            limit: value === 'all' ? null : Number(value),
          });
        }}
        value={limit === null ? 'all' : limit.toString()}
      >
        <SelectTrigger className="w-auto">
          <SelectValue />
        </SelectTrigger>
        <SelectContent>
          <SelectItem value="all">All</SelectItem>
          {[20, 50, 100].map(n => (
            <SelectItem key={n} value={n.toString()}>{n}</SelectItem>
          ))}
        </SelectContent>
      </Select>
      <span className="text-sm">items per page</span>
    </div>
  );
}