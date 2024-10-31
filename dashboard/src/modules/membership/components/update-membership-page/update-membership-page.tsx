import { redirect } from 'next/navigation';

import { ApiResponse } from '@/core/api/types';
import { GetMembershipResponse } from '../../types';

import { formatMemberNames } from '@/modules/member/utils';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { DashboardContentHeader, DashboardContentTitle } from '@/modules/dashboard/components/dashboard-content-header';

import { BackButton } from '@/modules/dashboard/components/back-button';
import { UpdateMembershipTabs } from './update-membership-tabs';

interface UpdateMembershipPageProps {
  searchParams: Record<string, string | string[] | undefined>;
}

export async function UpdateMembershipPage({
  searchParams,
}: UpdateMembershipPageProps) {
  const id = searchParams.id;

  if (!id) redirect('/dashboard/memberships');

  const res = await fetch(`${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships/${id}`);

  const membership: ApiResponse<GetMembershipResponse> = await res.json();

  if (!membership.data) redirect('/dashboard/memberships');

  return (
    <DashboardContent>
      <DashboardContentHeader>
        <DashboardContentTitle
          title="Manage Membership"
          description={membership.data.members
            ? formatMemberNames(membership.data.members)
            : undefined
          }
        />
        <BackButton href={`/dashboard/memberships/${membership.data.id}`} />
      </DashboardContentHeader>
      <UpdateMembershipTabs membership={membership.data} />
    </DashboardContent>
  );
}