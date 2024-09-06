import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectValue,
} from '@/components/ui/select';

interface SelectFilterProps<T extends string> {
  value: T;
  options: {
    value: T;
    label: string;
  }[];
  onChange: (e: any) => void;
}

export function SelectFilter<T extends string>({
  value,
  options,
  onChange,
}: SelectFilterProps<T>) {
  return (
    <Select
      onValueChange={onChange}
      value={value.toString()}
    >
      <SelectTrigger>
        <SelectValue>
          {options.find(o => o.value === value)?.label}
        </SelectValue>
      </SelectTrigger>
      <SelectContent className="w-auto">
        <SelectGroup>
          {options.map(({ value, label }) => (
            <SelectItem
              key={value}
              value={value.toString()}
            >
              {label}
            </SelectItem>
          ))}
        </SelectGroup>
      </SelectContent>
    </Select>
  );
}