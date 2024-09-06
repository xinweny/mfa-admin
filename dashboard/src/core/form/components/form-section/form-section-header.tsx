import { cn } from '@/lib/cn';

interface FormSectionHeaderProps {
  children: React.ReactNode;
  className?: string;
}

export function FormSectionHeader({
  children,
  className,
}: FormSectionHeaderProps) {
  return (
    <h3 className={cn('text-xl font-semibold border-b mb-2', className)}>{children}</h3>
  );
}