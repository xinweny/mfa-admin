import Link from 'next/link';

import { NavbarLinkList } from './components/navbar-link-list'; 

import TomoIcon from '@/assets/icons/tomo.svg';

export function DashboardNavbar() {
  return (
    <nav className="flex-shrink-0 w-auto min-w-auto p-2 overflow-y-auto bg-secondary">
      <div className="flex items-center gap-2 mb-4">
        <TomoIcon className="flex-shrink-0 w-10 h-10 fill-primary" />
        <h1 className="font-bold text-xl">Dashboard</h1>
      </div>
      <NavbarLinkList />
    </nav>
  );
}