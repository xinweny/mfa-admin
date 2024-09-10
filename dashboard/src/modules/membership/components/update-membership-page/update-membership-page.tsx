import { redirect } from 'next/navigation';

import { ApiResponse } from '@/core/api/types';
import { GetMembershipResponse } from '../../types';

import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';
import { DashboardContentHeader, DashboardContentHeading } from '@/modules/dashboard/components/dashboard-content-header';

import { UpdateMembershipForm } from '../update-membership-form';
import { BackButton } from '@/modules/dashboard/components/back-button';
import { DashboardTabs } from '@/modules/dashboard/components/dashboard-tabs';
import { UpsertAddressForm } from '@/modules/address/components/upsert-address-form';

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
      <DashboardContentHeader>
        <DashboardContentHeading text="Edit Membership" />
        <BackButton href={`/dashboard/memberships/${membership.data.id}`} />
      </DashboardContentHeader>
      <DashboardTabs
        defaultValue="membership"
        tabs={[
          {
            value: 'membership',
            label: 'Membership',
            component: <UpdateMembershipForm membership={membership.data} />,
          },
          {
            value: 'address',
            label: 'Address',
            component: <UpsertAddressForm
              membershipId={membership.data.id}
              address={membership.data.address}
            />,
          },
          {
            value: 'Members',
            label: 'Members',
            component: null,
          },
        ]}
      />
    </DashboardContent>
  );
}