import { MultiSelect, MultiSelectProps } from '@/components/ui/multi-select';
import { FieldValues, UseFieldArrayReturn } from 'react-hook-form';

interface MultiSelectFilterProps extends MultiSelectProps {}

export function MultiSelectFilter({
  ...props
}: MultiSelectFilterProps) {
  return (
    <MultiSelect
      {...props}
    />
  );
}