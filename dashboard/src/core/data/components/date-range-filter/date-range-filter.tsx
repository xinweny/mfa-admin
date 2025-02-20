import { format } from 'date-fns';
import { CalendarIcon } from 'lucide-react';
import { DateRange } from 'react-day-picker';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { cn } from '@/lib/cn';

import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from '@/components/ui/popover';
import { Button } from '@/components/ui/button';
import { Calendar } from '@/components/ui/calendar';

interface DateRangeFilterProps {
  date: DateRange;
  onChange: (e?: DateRange) => void;
}

export function DateRangeFilter({
  date,
  onChange,
}: DateRangeFilterProps) {
  const hasNoDatesSelected = !date.from && !date.to;

  return (
    <Popover>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          className={cn(
            "w-auto justify-start text-left font-normal",
            hasNoDatesSelected && "text-muted-foreground"
          )}
        >
          <CalendarIcon className="mr-2 h-4 w-4" />
          <span>
            {hasNoDatesSelected
              ? 'Select dates'
              : `${date.from ? format(date.from, 'dd/LL/yyyy') : ''} - ${date.to ? format(date.to, 'dd/LL/yyyy') : ''}`
            }
          </span>
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-auto p-0" align="start">
        <Calendar
          initialFocus
          mode="range"
          captionLayout="dropdown-buttons"
          defaultMonth={date?.from}
          selected={date}
          onSelect={onChange}
          numberOfMonths={1}
          fromYear={MFA_FOUNDING_YEAR}
          toYear={new Date().getFullYear()}
        />
      </PopoverContent>
    </Popover>
  );
}