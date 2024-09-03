'use client';

import { usePaginationUrlParams } from '@/core/data/state';

import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationLink,
  PaginationNext,
  PaginationPrevious,
  PaginationEllipsis,
} from '@/components/ui/pagination';

interface PaginationNavProps {
  currentPage: number;
  totalPages: number;
  maxPages: number;
}

export function PaginationNav({
  currentPage,
  totalPages,
  maxPages,
}: PaginationNavProps) {
  const [{ page }, setParams] = usePaginationUrlParams();

  const showLeftEllipsis = currentPage - 1 > maxPages / 2;
  const showRightEllipsis = totalPages - currentPage + 1 > maxPages / 2;

  const getPageNumbers = () => {
    if (totalPages <= maxPages) return Array.from({ length: totalPages }, (_, i) => i + 1);

    const half = Math.floor(maxPages / 2);
    // To ensure that the current page is always in the middle
    let start = currentPage - half;
    let end = currentPage + half;
    // If the current page is near the start
    if (start < 1) {
      start = 1;
      end = maxPages;
    }
    // If the current page is near the end
    if (end > totalPages) {
      start = totalPages - maxPages + 1;
      end = totalPages;
    }
    // If showLeftEllipsis is true, add an ellipsis before the start page
    if (showLeftEllipsis) start++;
    // If showRightEllipsis is true, add an ellipsis after the end page
    if (showRightEllipsis) end--;

    return Array.from({ length: end - start + 1 }, (_, i) => start + i);
  };

  return (
    <Pagination className="w-auto">
      <PaginationContent>
        <PaginationItem>
          <PaginationPrevious
            onClick={() => {
              setParams(params => ({
                ...params,
                page: page - 1,
              }))
            }}
            aria-disabled={page <= 1}
            tabIndex={page <= 1 ? -1 : undefined}
            className={page <= 1 ? 'pointer-events-none opacity-50' : undefined}
          />
        </PaginationItem>
        {showLeftEllipsis && (
          <PaginationItem>
            <PaginationEllipsis />
          </PaginationItem>
        )}
        {getPageNumbers().map((p) => {          
          return (
            <PaginationItem
              key={p}
            >
              <PaginationLink
                onClick={() => {
                  setParams(params => ({
                    ...params,
                    page: p,
                  }))
                }}
                aria-disabled={currentPage === p}
                tabIndex={currentPage === p ? -1 : undefined}
                isActive={currentPage === p}
              >
                {p}
              </PaginationLink>
            </PaginationItem>
          );
        })}
        {showRightEllipsis && (
          <PaginationItem>
            <PaginationEllipsis />
          </PaginationItem>
        )}
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
  );
}