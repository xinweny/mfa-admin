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
  FormLabel,
  FormControl,
  FormDescription,
  FormMessage,
} from '@/components/ui/form';

interface DashboardFormFieldProps<T extends FieldValues> {
  name: Path<T>;
  render: (field: ControllerRenderProps<T, Path<T>>) => ReactElement<any, string | JSXElementConstructor<any>>;
  label: string;
  description?: string;
}

export function DashboardFormField<T extends FieldValues>({
  name,
  label,
  render,
  description,
}: DashboardFormFieldProps<T>) {
  const { control } = useFormContext<T>();

  return (
    <FormField
      control={control}
      name={name}
      render={({ field }) => (
        <FormItem>
          <FormLabel>{label}</FormLabel>
          {description && (
            <FormDescription>{description}</FormDescription>
          )}
          <FormControl>
            {render(field)}
          </FormControl>
          <FormMessage />
        </FormItem>
      )}
    />
  );
}