import { useRouter } from 'next/navigation';
import { LucideIcon } from 'lucide-react';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface LinkDropdownMenuItemProps {
  href: string;
  icon: LucideIcon
  label: string;
}

export function LinkDropdownMenuItem({
  href,
  icon,
  label,
}: LinkDropdownMenuItemProps) {
  const router = useRouter();

  return (
    <RowDropdownMenuItem
      onClick={() => {
        router.push(href);
      }}
      icon={icon}
      label={label}
    />
  );
}