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
    value: string;
    label: string;
  }[];
  onChange: (e: any) => void;
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
      value={value}
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