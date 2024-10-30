import { ReactElement, JSXElementConstructor } from 'react';
import {
  FieldValues,
  useFormContext,
  Path,
  ControllerRenderProps,
} from 'react-hook-form';

import {
  FormField,
  FormItem,
  FormControl,
  FormMessage,
} from '@/components/ui/form';
import { TableCell } from '@/components/ui/table';

interface TableCellFieldProps<T extends FieldValues> {
  name: Path<T>;
  render: (field: ControllerRenderProps<T, Path<T>>) => ReactElement<any, string | JSXElementConstructor<any>>;
}

export function TableCellField<T extends FieldValues>({
  name,
  render,
}: TableCellFieldProps<T>) {
  const { control } = useFormContext<T>();

  return (
    <TableCell>
      <FormField
        control={control}
        name={name}
        render={({ field }) => (
          <FormItem>
            <FormControl>
              {render(field)}
            </FormControl>
            <FormMessage />
          </FormItem>
        )}
      />
    </TableCell>
  );
}