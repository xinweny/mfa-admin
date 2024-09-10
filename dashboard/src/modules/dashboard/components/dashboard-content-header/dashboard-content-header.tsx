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

interface DashboardContentHeadingProps {
  text: string;
}

export function DashboardContentHeading({
  text,
}: DashboardContentHeadingProps) {
  return (
    <h1 className="text-3xl font-bold">{text}</h1>
  );
}