'use client';

import { PaginationMetadata } from '@/core/api/types';

import { PaginationInfo } from './pagination-info';
import { PaginationLimitSelect } from './pagination-limit-select';
import { PaginationNav } from './pagination-nav';

interface DataTablePaginationProps {
  pagination: PaginationMetadata | null;
}

export function DataTablePagination({
  pagination,
}: DataTablePaginationProps) {
  if (!pagination) return null;

  const {
    currentPage,
    currentCount,
    totalPages,
    totalCount,
    pageSize,
  } = pagination;

  return (
    <div className="grid grid-cols-3 items-center w-full">
      <PaginationLimitSelect />
      <PaginationNav
        currentPage={currentPage || 1}
        totalPages={totalPages || 1}
        maxPages={6}
      />
      <PaginationInfo
        totalCount={totalCount || 0}
        currentCount={currentCount || 0}
        pageSize={pageSize}
      />
    </div>
  );
}

