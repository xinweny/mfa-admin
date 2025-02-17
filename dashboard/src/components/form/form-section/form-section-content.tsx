import { cn } from '@/lib/cn';

interface FormSectionContentProps {
  children: React.ReactNode;
  className?: string;
}

export function FormSectionContent({
  children,
  className,
}: FormSectionContentProps) {
  return (
    <fieldset className={cn('flex flex-col gap-2', className)}>
      {children}
    </fieldset>
  );
}