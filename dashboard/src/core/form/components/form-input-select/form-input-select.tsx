import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectValue,
} from '@/components/ui/select';

interface FormInputSelectProps {
  value: string;
  options: {
    value: any;
    label: string;
  }[];
  onChange: (value: string) => void;
  placeholder?: string;
}

export function FormInputSelect({
  value,
  options,
  onChange,
  placeholder,
}: FormInputSelectProps) {
  return (
    <Select
      onValueChange={onChange}
      value={value?.toString()}
    >
      <SelectTrigger>
        <SelectValue placeholder={placeholder}>
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