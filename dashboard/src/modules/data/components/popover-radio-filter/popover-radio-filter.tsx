import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from '@/components/ui/popover';
import { Button } from '@/components/ui/button';
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { Label } from '@/components/ui/label';

interface PopoverRadioFilterProps<T extends string> {
  currentValue: T;
  values: {
    value: T;
    label: string;
  }[];
  onChange: (e: any) => void;
}

export function PopoverRadioFilter<T extends string>({
  currentValue,
  values,
  onChange,
}: PopoverRadioFilterProps<T>) {
  return (
    <Popover>
      <PopoverTrigger asChild>
        <Button variant="outline" className="justify-start">
          {values.find(v => v.value === currentValue)?.label}
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-auto">
        <RadioGroup
          onValueChange={onChange}
          defaultValue={currentValue}
        >
          {values.map(({ value, label }) => (
            <div key={value} className="flex items-center gap-2">
              <RadioGroupItem value={value} />
              <Label>{label}</Label>
            </div>
          ))}
        </RadioGroup>
      </PopoverContent>
    </Popover>
  );
}