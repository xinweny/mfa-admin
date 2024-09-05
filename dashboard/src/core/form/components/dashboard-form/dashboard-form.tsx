import { UseFormReturn, FieldValues } from 'react-hook-form';

import { cn } from '@/lib/cn';

import { Button } from '@/components/ui/button';
import { Form } from '@/components/ui/form';

interface DashboardFormProps<T extends FieldValues> {
  form: UseFormReturn<T, any, undefined>
  children: React.ReactNode;
  onSubmit: (data: T) => void;
  className?: string;
  submitLabel?: string;
  reset?: () => void;
}

export function DashboardForm<T extends FieldValues>({
  form,
  children,
  onSubmit,
  className,
  submitLabel = 'Submit',
  reset = () => {},
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
        <div className={"flex gap-2 mt-2"}>
          {reset && (
            <Button
              type="button"
              variant="secondary"
              onClick={reset}
              className="flex-grow"
            >
              Reset
            </Button>
          )}
          <Button
            type="submit"
            className={"flex-grow"}
          >
            {submitLabel}
          </Button>
        </div>
      </form>
    </Form>
  )
}