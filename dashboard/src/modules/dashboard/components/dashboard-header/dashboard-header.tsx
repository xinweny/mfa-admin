import { DashboardCommand } from '../dashboard-command';
import { ThemeSwitch } from '../theme-switch';

export function DashboardHeader() {
  return (
    <header className="p-2 w-full flex justify-between items-center border-b">
      <DashboardCommand />
      <ThemeSwitch />
    </header>
  );
}