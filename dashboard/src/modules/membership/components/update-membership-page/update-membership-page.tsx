import { redirect } from 'next/navigation';

import { ApiResponse } from '@/core/api/types';
import { GetMembershipResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

import { UpdateMembershipForm } from '../update-membership-form';

interface UpdateMembershipPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function UpdateMembershipPage({
  searchParams,
}: UpdateMembershipPageProps) {
  const id = searchParams.id;

  if (!id) redirect('/dashboard/memberships');

  const res = await fetch(`${process.env.MFA_API_URL}/memberships/${id}`);

  const membership: ApiResponse<GetMembershipResponse> = await res.json();

  if (!membership.data) redirect('/dashboard/memberships');

  return (
    <DashboardContent>
      <UpdateMembershipForm membership={membership.data} />
    </DashboardContent>
  );
}