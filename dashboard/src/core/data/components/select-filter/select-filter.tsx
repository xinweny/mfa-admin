import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectGroup,
  SelectItem,
} from '@/components/ui/select';
import { SelectValue } from '@radix-ui/react-select';

interface SelectFilterProps<T extends string> {
  currentValue: T;
  values: {
    value: T;
    label: string;
  }[];
  onChange: (e: any) => void;
}

export function SelectFilter<T extends string>({
  currentValue,
  values,
  onChange,
}: SelectFilterProps<T>) {
  return (
    <Select
      onValueChange={onChange}
      defaultValue={currentValue}
    >
      <SelectTrigger>
        <SelectValue>
          {values.find(v => v.value === currentValue)?.label}
        </SelectValue>
      </SelectTrigger>
      <SelectContent className="w-auto">
        <SelectGroup>
          {values.map(({ value, label }) => (
            <SelectItem
              key={value}
              value={value}
            >
              {label}
            </SelectItem>
          ))}
        </SelectGroup>
      </SelectContent>
    </Select>
  );
}