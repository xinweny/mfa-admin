import { UseFormReturn, FieldValues } from 'react-hook-form';

import { cn } from '@/lib/cn';

import { Form } from '@/components/ui/form';

interface DashboardFormProps<T extends FieldValues> {
  form: UseFormReturn<T, any, undefined>
  children: React.ReactNode;
  onSubmit: (data: T) => void;
  className?: string;
}

export function DashboardForm<T extends FieldValues>({
  form,
  children,
  onSubmit,
  className,
}: DashboardFormProps<T>) {
  return (
    <Form {...form}>
      <form
        className={cn(
          'flex flex-col gap-2',
          className
        )}
        onSubmit={form.handleSubmit(onSubmit)}
      >
        {children}
      </form>
    </Form>
  )
}

interface DashboardFormTitleProps {
  title: string;
}

export function DashboardFormTitle({
  title,
}: DashboardFormTitleProps) {
  return (
    <h1 className="text-2xl font-bold">{title}</h1>
  );
}