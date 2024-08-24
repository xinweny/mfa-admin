'use client';

import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { LucideIcon } from 'lucide-react';

import { cn } from '@/lib';

export interface NavbarLinkItemProps {
  href: string;
  label: string;
  icon: LucideIcon;
  exactHref?: boolean;
}

export function NavbarLinkItem({
  href,
  label,
  icon,
  exactHref = false,
}: NavbarLinkItemProps) {
  const Icon = icon;

  const pathname = usePathname();

  const isActive = exactHref
    ? pathname === href
    : pathname.includes(href);

  return (
    <li className={cn(
      'px-4 py-1 rounded-md',
      isActive
        ? 'bg-primary text-white'
        : 'hover:bg-secondary',
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