'use client';

import { Key } from 'react';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuCheckboxItem,
  DropdownMenuContent,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { Badge } from '@/components/ui/badge';

interface MultiSelectFilterProps<T> {
  options: {
    value: T;
    label: string;
  }[];
  values: T[];
  onChange: (values: T[]) => void;
}

export function MultiSelectFilter<T>({
  values,
  options,
  onChange,
}: MultiSelectFilterProps<T>) {
  const selectedOptions = options.filter(o => values.includes(o.value));

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button
          variant="outline"
          className="gap-1 flex-wrap"
        >
          {selectedOptions.length === 0
            ? 'All'
            : selectedOptions.map(o => (
              <Badge key={o.value as Key}>
                {o.label}
              </Badge>
            ))}
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent>
        {options.map(({ value, label }) => (
          <DropdownMenuCheckboxItem
            key={value as Key}
            checked={!!values.find(v => value === v)}
            onCheckedChange={checked => {
              onChange(checked
                ? [...values, value]
                : values.filter(v => v !== value)
              );
            }}
          >
            {label}
          </DropdownMenuCheckboxItem>
        ))}
      </DropdownMenuContent>
    </DropdownMenu>
  )
}
