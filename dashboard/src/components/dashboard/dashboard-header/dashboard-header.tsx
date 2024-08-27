import { DashboardCommand } from '../dashboard-command/dashboard-command';

export function DashboardHeader() {
  return (
    <header className="bg-primary p-2">
      <DashboardCommand />
    </header>
  );
}