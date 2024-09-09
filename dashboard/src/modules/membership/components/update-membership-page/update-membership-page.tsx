import { redirect } from 'next/navigation';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

interface UpdateMembershipPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function UpdateMembershipPage({
  searchParams,
}: UpdateMembershipPageProps) {
  const id = searchParams.id;

  if (!id) redirect('/dashboard/memberships');

  const res = await fetch(`${process.env.MFA_API_URL}/memberships/${id}`);

  const membership = await res.json();

  if (!membership.data) redirect('/dashboard/memberships');

  return (
    <DashboardContent>
      update
    </DashboardContent>
  );
}