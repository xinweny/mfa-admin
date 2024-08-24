import { DashboardHeader } from '../dashboard-header';
import { DashboardNavbar } from '../dashboard-navbar';

interface DashboardLayoutProps {
  children: React.ReactNode;
}

export function DashboardLayout({
  children,
}: DashboardLayoutProps) {
  return (
    <div className="w-full h-full">
      <DashboardNavbar />
      <DashboardHeader />
      {children}
    </div>
  );
}