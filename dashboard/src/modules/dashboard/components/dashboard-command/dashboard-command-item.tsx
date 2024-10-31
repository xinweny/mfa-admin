import { LucideIcon } from 'lucide-react';

import { CommandItem } from '@/components/ui/command';

interface DashboardCommandItemProps {
  icon: LucideIcon;
  label: string;
  onClick: () => void;
}

export function DashboardCommandItem({
  icon,
  label,
  onClick,
}: DashboardCommandItemProps) {
  const Icon = icon;

  return (
    <CommandItem
      className="flex items-center gap-2 hover:cursor-pointer"
      onClick={onClick}
    >
      <Icon />
      <span className="text-sm font-medium">{label}</span>
    </CommandItem>
  );
}