import { LucideIcon } from 'lucide-react';

import { CommandItem } from '@/components/ui/command';

interface DashboardCommandItemProps {
  icon: LucideIcon;
  label: string;
  onSelect: () => void;
  setOpen: (isOpen: boolean) => void;
}

export function DashboardCommandItem({
  icon,
  label,
  onSelect,
  setOpen,
}: DashboardCommandItemProps) {
  const Icon = icon;

  return (
    <CommandItem
      className="flex items-center gap-2 hover:cursor-pointer"
      onSelect={() => {
        onSelect();
        setOpen(false);
      }}
    >
      <Icon />
      <span className="text-sm font-medium">{label}</span>
    </CommandItem>
  );
}