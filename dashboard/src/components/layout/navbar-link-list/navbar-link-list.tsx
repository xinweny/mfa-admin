'use client';

import { usePathname } from 'next/navigation';

import {
  IdCardIcon,
  UsersIcon,
  CircleDollarSignIcon,
  HeartHandshakeIcon,
  NetworkIcon,
} from 'lucide-react';

import { NavbarLinkItemProps, NavbarLinkItem } from '../navbar-link-item';

export function NavbarLinkList() {
  const pathname = usePathname();

  return (
    <ul>
      {links.map(({ href, label, icon }) => (
        <NavbarLinkItem
          key={href}
          href={href}
          label={label}
          icon={icon}
          isActive={pathname.includes(href)}
        />
      ))}
    </ul>
  );
}

const links = [
  { 
    href: '/members',
    label: 'Members',
    icon: UsersIcon,
  },
  { 
    href: '/memberships',
    label: 'Memberships',
    icon: IdCardIcon,
  },
  {
    href: '/payments',
    label: 'Payments',
    icon: CircleDollarSignIcon,
  },
  {
    href: '/exchanges',
    label: 'Hosting & Delegation',
    icon: HeartHandshakeIcon,
  },
  {
    href: '/board',
    label: 'Board',
    icon: NetworkIcon,
  },
] satisfies Omit<NavbarLinkItemProps, 'isActive'>[];