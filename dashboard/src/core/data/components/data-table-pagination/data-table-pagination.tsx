'use client';

import { PaginationInfo } from './components/pagination-info';
import { PaginationLimitSelect } from './components/pagination-limit-select';
import { PaginationNav } from './components/pagination-nav/pagination-nav';

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
  return (
    <div className="grid grid-cols-3 items-center w-full">
      <PaginationLimitSelect />
      <PaginationNav
        currentPage={currentPage}
        totalPages={totalPages}
        maxPages={6}
      />
      <PaginationInfo
        totalCount={totalCount}
        currentCount={currentCount}
        pageSize={pageSize}
      />
    </div>
  );
}

