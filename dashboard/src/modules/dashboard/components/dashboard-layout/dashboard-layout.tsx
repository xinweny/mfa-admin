import { getSession } from '@auth0/nextjs-auth0';
import { redirect } from 'next/navigation';

import { DashboardHeader } from '../dashboard-header';
import { DashboardNavbar } from '../dashboard-navbar';

interface DashboardLayoutProps {
  children: React.ReactNode;
}

export async function DashboardLayout({
  children,
}: DashboardLayoutProps) {
  const session = await getSession();

  if (!session?.user) redirect('/api/auth/login');

  return (
    <div className="w-screen h-screen flex overflow-hidden">
      <DashboardNavbar />
      <div className="flex-grow overflow-y-auto">
        <DashboardHeader />
        {children}
      </div>
    </div>
  );
}