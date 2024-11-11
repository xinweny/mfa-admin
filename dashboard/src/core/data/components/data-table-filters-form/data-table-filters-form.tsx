'use client';

import { ReactElement, JSXElementConstructor } from 'react';
import {
  Controller,
  UseFormReturn,
  FieldValues,
  ControllerRenderProps,
  ControllerFieldState,
  UseFormStateReturn,
  Path,
} from 'react-hook-form';

import { Button } from '@/components/ui/button';

import { DataTableFilter } from './data-table-filter';

interface DataTableFiltersFormProps<T extends FieldValues> {
  form: UseFormReturn<T, any, undefined>;
  onSubmit: (data: T) => void;
  filters: {
    label: string;
    name: Path<T>;
    render: (field: {
      field: ControllerRenderProps<T, Path<T>>;
      fieldState: ControllerFieldState;
      formState: UseFormStateReturn<T>;
    }) => ReactElement<any, string | JSXElementConstructor<any>>;
  }[];
  reset?: T,
}

export function DataTableFiltersForm<T extends FieldValues>({
  form,
  onSubmit,
  filters,
  reset,
}: DataTableFiltersFormProps<T>) {
  const {
    handleSubmit,
    control,
  } = form;

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className="flex flex-wrap gap-2 items-center"
    >
      {filters.map(({
        label,
        name,
        render,
      }) => (
        <DataTableFilter
          key={name}
          name={name}
          label={label}
        >
          <Controller
            name={name}
            control={control}
            render={render}
          />
        </DataTableFilter>
      ))}
      <div className="self-end flex items-end gap-2">
        <Button
          variant="link"
          onClick={() => {
            form.reset(reset);
          }}
        >
          Reset
        </Button>
        <Button
          type="submit"
        >
          Apply
        </Button>
      </div>
    </form>
  );
}