'use client';

import { useGetMembershipDuesUrlParams } from '@/modules/stats/state';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectValue,
  SelectItem,
} from '@/components/ui/select';

export function DueYearSelect() {
  const [{ dueYear }, setParams] = useGetMembershipDuesUrlParams();

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
          { length: new Date().getFullYear() - MFA_FOUNDING_YEAR + 1 },
          (_, i) => MFA_FOUNDING_YEAR + i
        ).map(year => (
          <SelectItem
            key={year}
            value={year.toString()}
          >
              {year}
            </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
}