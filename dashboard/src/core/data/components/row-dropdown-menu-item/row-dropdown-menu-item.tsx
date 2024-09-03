import { LucideIcon } from 'lucide-react';

import { cn } from '@/lib/cn';

import { DropdownMenuItem } from '@/components/ui/dropdown-menu';

interface RowDropdownMenuItemProps {
  onClick: () => void;
  icon: LucideIcon;
  label: string;
  className?: string;
}

export function RowDropdownMenuItem({
  onClick,
  icon,
  label,
  className,
}: RowDropdownMenuItemProps) {
  const Icon = icon;

  return (
    <DropdownMenuItem
      onClick={onClick}
      className={cn('flex items-center gap-4 cursor-pointer', className)}
    >
      <Icon width={16} />
      <span className="text-sm font-medium">{label}</span>
    </DropdownMenuItem>
  );
}