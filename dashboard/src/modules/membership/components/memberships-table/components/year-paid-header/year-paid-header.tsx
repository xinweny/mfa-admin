'use client';

import { useGetMembershipsUrlParams } from '@/modules/membership/state';

import { Label } from '@/components/ui/label';

export function YearPaidHeader() {
  const [{ yearPaid }] = useGetMembershipsUrlParams();

  return (
    <Label htmlFor="year-paid">{`Paid ${yearPaid}`}</Label>
  );
}