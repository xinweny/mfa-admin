'use client';

import { usePaginationUrlParams } from '../../state';

import {
  Select,
  SelectItem,
  SelectTrigger,
  SelectContent,
  SelectValue,
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
  pagination: {
    currentPage: number;
    currentCount: number;
    totalPages: number;
    totalCount: number;
    pageSize: number | null;
  };
}

export function DataTablePagination({
  pagination: {
    currentPage,
    currentCount,
    totalPages,
    totalCount,
    pageSize,
  },
}: DataTablePaginationProps) {
  const [{ page, limit }, setParams] = usePaginationUrlParams();

  return (
    <div className="grid grid-cols-3 items-center">
      <div className="flex items-center gap-2">
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
            <SelectItem value="20">20</SelectItem>
            <SelectItem value="50">50</SelectItem>
            <SelectItem value="100">100</SelectItem>
          </SelectContent>
        </Select>
        <span className="text-sm">items per page</span>
      </div>
      <Pagination className="w-auto">
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
              tabIndex={page <= 1 ? -1 : undefined}
              className={page <= 1 ? 'pointer-events-none opacity-50' : undefined}
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
                  aria-disabled={currentPage === p}
                  tabIndex={currentPage === p ? -1 : undefined}
                  className={currentPage === p ? 'pointer-events-none' : undefined}
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
              tabIndex={page >= totalPages ? -1 : undefined}
              className={page >= totalPages ? 'pointer-events-none opacity-50' : undefined}
            />
          </PaginationItem>
        </PaginationContent>
      </Pagination>
      <span className="text-sm text-right">
        <span className="font-bold">{pageSize ? ((page - 1) * pageSize) + 1 : 1}</span>
        <span> - </span>
        <span className="font-bold">{currentCount}</span>
        <span> of </span>
        <span className="font-bold">{totalCount}</span>
        <span> items</span>
      </span>
    </div>
  );
}

