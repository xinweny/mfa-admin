'use client';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuCheckboxItem,
  DropdownMenuContent,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { Badge } from '@/components/ui/badge';

interface MultiSelectFilterProps {
  options: {
    value: string;
    label: string;
  }[];
  values: string[];
  onChange: (values: string[]) => void;
}

export function MultiSelectFilter({
  values,
  options,
  onChange,
}: MultiSelectFilterProps) {
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
              <Badge key={o.value}>
                {o.label}
              </Badge>
            ))}
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent>
        {options.map(({ value, label }) => (
          <DropdownMenuCheckboxItem
            key={value}
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
