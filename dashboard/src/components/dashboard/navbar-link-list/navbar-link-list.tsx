'use client';

import {
  IdCardIcon,
  UsersIcon,
  CircleDollarSignIcon,
  HeartHandshakeIcon,
  NetworkIcon,
  ChartBarIcon
} from 'lucide-react';

import { NavbarLinkItemProps, NavbarLinkItem } from '../navbar-link-item';

export function NavbarLinkList() {
  return (
    <ul className="space-y-0.5">
      {links.map(({ href, label, icon }) => (
        <NavbarLinkItem
          key={href}
          href={`/dashboard${href}`}
          label={label}
          icon={icon}
        />
      ))}
    </ul>
  );
}

const links = [
  {
    href: '',
    label: 'Summary',
    icon: ChartBarIcon,
    exactHref: true,
  },
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
] satisfies NavbarLinkItemProps[];