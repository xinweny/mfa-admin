import { cn } from '@/lib/cn';

interface DashboardContentHeaderProps {
  children: React.ReactNode;
  className?: string;
}

export function DashboardContentHeader({
  children,
  className,
}: DashboardContentHeaderProps) {
  return (
    <div className={cn('flex items-center justify-between mb-4', className)}>
      {children}
    </div>
  );
}

