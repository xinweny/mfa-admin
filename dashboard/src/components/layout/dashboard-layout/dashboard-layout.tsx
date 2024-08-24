import { DashboardHeader } from '../dashboard-header';
import { DashboardNavbar } from '../dashboard-navbar';

interface DashboardLayoutProps {
  children: React.ReactNode;
}

export function DashboardLayout({
  children,
}: DashboardLayoutProps) {
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