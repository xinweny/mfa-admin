import { format } from 'date-fns';
import { SelectSingleEventHandler } from 'react-day-picker';

import { cn } from '@/lib/cn';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from '@/components/ui/popover';
import { Button } from '@/components/ui/button';
import { CalendarIcon } from 'lucide-react';
import { Calendar } from '@/components/ui/calendar';


interface FormInputDateProps {
  value: Date | undefined;
  onChange: (date: any) => void;
  fromYear?: number;
  toYear?: number;
}

export function FormInputDate({
  value,
  onChange,
  fromYear = MFA_FOUNDING_YEAR,
  toYear = new Date().getFullYear(),
}: FormInputDateProps) {
  return (
    <Popover>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          className={cn(
            "w-auto justify-start text-left font-normal",
            !value && "text-muted-foreground"
          )}
        >
          <CalendarIcon className="mr-2 h-4 w-4" />
          <span>
            {value
              ? format(value, 'dd/LL/yyyy')
              : 'Select date'
            }
          </span>
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-auto p-0" align="start">
        <Calendar
          initialFocus
          mode="single"
          captionLayout="dropdown-buttons"
          selected={value}
          defaultMonth={value}
          onSelect={onChange}
          numberOfMonths={1}
          fromYear={fromYear}
          toYear={toYear}
        />
      </PopoverContent>
    </Popover>
  );
}