import { Input, InputProps } from '@/components/ui/input';

interface TextInputFilterProps extends InputProps {};

export function TextInputFilter({
  ...props
}: TextInputFilterProps) {
  return (
    <Input {...props} />
  );
}