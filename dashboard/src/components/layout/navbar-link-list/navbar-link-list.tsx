'use client';

import { usePathname } from 'next/navigation';

import { RiOrganizationChart } from 'react-icons/ri';
import { PiUsersThreeBold } from 'react-icons/pi';
import { MdCardMembership } from 'react-icons/md';
import { LuCircleDollarSign } from 'react-icons/lu';
import { TbHeartHandshake } from 'react-icons/tb';

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
    icon: PiUsersThreeBold,
  },
  { 
    href: '/memberships',
    label: 'Memberships',
    icon: MdCardMembership,
  },
  {
    href: '/payments',
    label: 'Payments',
    icon: LuCircleDollarSign,
  },
  {
    href: '/exchanges',
    label: 'Hosting & Delegation',
    icon: TbHeartHandshake,
  },
  {
    href: '/board',
    label: 'Board',
    icon: RiOrganizationChart,
  },
] satisfies Omit<NavbarLinkItemProps, 'isActive'>[];