import { Input, InputProps } from '@/components/ui/input';

interface NumberInputFilterProps extends InputProps {}

export function NumberInputFilter({
  ...props
}: NumberInputFilterProps) {
  return (
    <Input
      type="number"
      className="w-auto"
      {...props}
    />
  );
}