'use client';

import { useGetMembershipsUrlParams } from '../../state';

import { Label } from '@/components/ui/label';

export function YearPaidFilter() {
  const [{ yearPaid }] = useGetMembershipsUrlParams();

  return (
    <Label htmlFor="year-paid">{`Paid ${yearPaid}`}</Label>
  );
}