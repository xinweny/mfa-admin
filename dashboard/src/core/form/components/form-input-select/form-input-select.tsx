import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectValue,
} from '@/components/ui/select';

interface FormInputSelectProps<T extends string> {
  value: T;
  options: {
    value: T;
    label: string;
  }[];
  onChange: (e: any) => void;
  placeholder?: string;
}

export function FormInputSelect<T extends string>({
  value,
  options,
  onChange,
  placeholder,
}: FormInputSelectProps<T>) {
  return (
    <Select
      onValueChange={onChange}
      defaultValue={value}
    >
      <SelectTrigger>
        <SelectValue placeholder={placeholder}>
          {options.find(v => v.value === value)?.label}
        </SelectValue>
      </SelectTrigger>
      <SelectContent className="w-auto">
        <SelectGroup>
          {options.map(({ value, label }) => (
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