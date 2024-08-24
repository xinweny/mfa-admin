import Link from 'next/link';
import { LucideIcon } from 'lucide-react';

import { cn } from '@/lib';

export interface NavbarLinkItemProps {
  href: string;
  label: string;
  icon: LucideIcon;
  isActive: boolean;
}

export function NavbarLinkItem({
  href,
  label,
  icon,
  isActive,
}: NavbarLinkItemProps) {
  const Icon = icon;

  return (
    <li className={cn(
      'px-4 py-1 rounded-md',
      isActive ? 'bg-primary' : 'hover:bg-secondary',
    )}>
      <Link href={href}>
        <div className="flex items-center gap-2">
          <Icon />
          <span className="text-sm font-semibold">{label}</span>
        </div>
      </Link>
    </li>
  );
}