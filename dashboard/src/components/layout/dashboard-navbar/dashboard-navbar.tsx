import Link from 'next/link';

import { NavbarLinkList } from '../navbar-link-list'; 

import TomoIcon from '@/assets/icons/tomo.svg';

export function DashboardNavbar() {
  return (
    <nav className="w-[300px] p-2">
      <div className="flex items-center gap-2 mb-4">
        <TomoIcon className="w-10 h-10" />
        <h1 className="font-bold text-xl">Dashboard</h1>
      </div>
      <NavbarLinkList />
    </nav>
  );
}