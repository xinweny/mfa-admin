import { DashboardHeader } from "../dashboard-header";

interface DashboardLayoutProps {
  children: React.ReactNode;
}

export function DashboardLayout({
  children,
}: DashboardLayoutProps) {
  return (
    <div>
      <DashboardHeader />
      {children}
    </div>
  );
}