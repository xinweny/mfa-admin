'use client';

import { useGetMembershipsSummaryUrlParams } from '@/modules/stats/state';

import { mfaFoundingYear } from '@/core/constants';

import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectValue,
  SelectItem,
} from '@/components/ui/select';

export function DueYearSelect() {
  const [{ dueYear }, setParams] = useGetMembershipsSummaryUrlParams();

  return (
    <Select
      value={dueYear.toString()}
      onValueChange={value => {
        setParams(prev => ({
          ...prev,
          dueYear: +value,
        }));
      }}
    >
      <SelectTrigger className="w-auto">
        <SelectValue />
      </SelectTrigger>
      <SelectContent>
        {Array.from(
          { length: new Date().getFullYear() - mfaFoundingYear + 1 },
          (_, i) => mfaFoundingYear + i
        ).map(year => (
          <SelectItem value={year.toString()}>{year}</SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}