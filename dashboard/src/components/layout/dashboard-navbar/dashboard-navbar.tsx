import Link from 'next/link';

import { NavbarLinkList } from '../navbar-link-list'; 

export function DashboardNavbar() {
  return (
    <nav className="w-[300px]">
      <Link href="/dashboard">
        <div className="flex items-center gap-2">
          <h1 className="font-bold text-xl">Dashboard</h1>
        </div>
      </Link>
      <NavbarLinkList />
    </nav>
  );
}