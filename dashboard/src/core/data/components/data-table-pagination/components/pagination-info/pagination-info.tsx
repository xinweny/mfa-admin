'use client';

import { usePaginationUrlParams } from '@/core/data/state';

interface PaginationInfoProps {
  pageSize: number | null;
  currentCount: number;
  totalCount: number;
}

export function PaginationInfo({
  pageSize,
  currentCount,
  totalCount,
}: PaginationInfoProps) {
  const [{ page }] = usePaginationUrlParams();
  
  return (
    <span className="text-sm place-self-start justify-self-end py-2">
      <span className="font-bold">{pageSize ? ((page - 1) * pageSize) + 1 : 1}</span>
      <span> - </span>
      <span className="font-bold">{currentCount}</span>
      <span> of </span>
      <span className="font-bold">{totalCount}</span>
      <span> items</span>
    </span>
  );
}