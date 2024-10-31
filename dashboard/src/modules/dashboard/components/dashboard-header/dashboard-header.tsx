import { UserDropdownMenu } from '@/core/auth/components/user-dropdown-menu';

import { DashboardCommand } from '../dashboard-command';
import { ThemeSwitch } from '../theme-switch';

export function DashboardHeader() {
  return (
    <header className="p-2 w-full flex justify-between items-center border-b">
      <DashboardCommand />
      <div className="flex items-center gap-2">
        <ThemeSwitch />
        <UserDropdownMenu />
      </div>
    </header>
  );
}