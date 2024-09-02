'use client';

import { usePaginationUrlParams } from '../../state';

import {
  Select,
  SelectItem,
  SelectTrigger,
  SelectContent,
  SelectValue
} from '@/components/ui/select';
import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationLink,
  PaginationNext,
  PaginationPrevious,
} from '@/components/ui/pagination';

interface DataTablePaginationProps {
  numItems: number;
  totalCount: number;
}

export function DataTablePagination({
  numItems,
  totalCount,
}: DataTablePaginationProps) {
  const [{ page, limit }, setParams] = usePaginationUrlParams();

  const totalPages = Math.ceil(totalCount / (limit || totalCount));

  return (
    <div className="flex flex-wrap items-center justify-between">
      <div className="flex items-center gap-2">
        <Select
          onValueChange={(value: string) => {
            setParams({
              page: null,
              limit: value === 'all' ? null : Number(value),
            });
          }}
        >
          <SelectTrigger className="w-[180px]">
            <SelectValue defaultValue={limit || 'all'} />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="all">All</SelectItem>
            <SelectItem value="20">20</SelectItem>
            <SelectItem value="50">50</SelectItem>
            <SelectItem value="100">100</SelectItem>
          </SelectContent>
        </Select>
        <span>items per page</span>
      </div>
      <span>
        <span className="font-bold">{limit ? ((page - 1) * limit) + 1 : 1}</span>
        <span> - </span>
        <span className="font-bold">{numItems}</span>
        <span> of </span>
        <span className="font-bold">{totalCount}</span>
        <span>items</span>
      </span>
      <Pagination>
        <PaginationContent>
          <PaginationItem>
            <PaginationPrevious
              onClick={() => {
                setParams(params => ({
                  ...params,
                  page: page + 1,
                }))
              }}
              aria-disabled={page <= 1}
            />
          </PaginationItem>
          {[...Array(totalPages)].map((_, i) => {
            const p = i + 1;
            
            return (
              <PaginationItem key={p}>
                <PaginationLink
                  onClick={() => {
                    setParams(params => ({
                      ...params,
                      page: p,
                    }))
                  }}
                  aria-disabled={page === p}
                >{p}</PaginationLink>
              </PaginationItem>
            );
          })}
          <PaginationItem>
            <PaginationNext
              onClick={() => {
                setParams(params => ({
                  ...params,
                  page: page + 1,
                }))
              }}
              aria-disabled={page >= totalPages}
            />
          </PaginationItem>
        </PaginationContent>
      </Pagination>
    </div>
  );
}

