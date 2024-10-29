import { DashboardFormTitle } from '@/core/form/components/dashboard-form';
import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { CreateDuesForm } from '../create-dues-form';

export function CreateDuesPage() {
  return (
    <DashboardContent>
      <DashboardFormTitle title="Create Due Receipts" />
      <CreateDuesForm />
    </DashboardContent>
  );
}