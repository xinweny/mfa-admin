'use client';

import { useState } from 'react';

import { mfaFoundingYear } from '@/constants';

import { useYearUrlParam } from '../../state';

import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';

export function DuesYearFilter() {
  const [year, setYear] = useYearUrlParam();

  const currentYear = new Date().getFullYear();

  const [y, setY] = useState<number>(year);

  return (
    <div className="flex items-center gap-2">
      <Label htmlFor="year-paid">Paid</Label>
      <Input
        className="w-auto"
        id="year-paid"
        type="number"
        min={mfaFoundingYear}
        max={currentYear}
        value={y}
        onChange={e => {
          setY(Number(e.currentTarget.value));
        }}
        onBlur={e => {
          setYear(Number(e.currentTarget.value));
        }}
      />
    </div>
  );
}