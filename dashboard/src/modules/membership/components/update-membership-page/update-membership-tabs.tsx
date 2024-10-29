'use client';

import {
  useUpdateMembershipTabsUrlParams,
  UpdateMembershipTabs as Tabs,
} from '../../state';

import { GetMembershipResponse } from '../../types';

import { UpdateMembershipForm } from '../update-membership-form';
import { DashboardTabs } from '@/modules/dashboard/components/dashboard-tabs';
import { UpsertAddressForm } from '@/modules/address/components/upsert-address-form';
import { UpdateMembersForm } from '@/modules/member/components/update-members-form';

interface UpdateMembershipTabsProps {
  membership: GetMembershipResponse;
}

export function UpdateMembershipTabs({
  membership,
}: UpdateMembershipTabsProps) {
  const [tab, setTab] = useUpdateMembershipTabsUrlParams();

  return (
    <DashboardTabs
      defaultValue={tab}
      tabs={[
        {
          value: Tabs.Membership,
          label: 'Membership',
          component: <UpdateMembershipForm membership={membership} />,
          onClick: () => { setTab(Tabs.Membership) },
        },
        {
          value: Tabs.Members,
          label: 'Members',
          component: <UpdateMembersForm
            members={membership.members}
            membershipId={membership.id}
            membershipType={membership.membershipType}
          />,
          onClick: () => { setTab(Tabs.Members) },
        },
        {
          value: Tabs.Address,
          label: 'Address',
          component: <UpsertAddressForm
            membershipId={membership.id}
            address={membership.address}
          />,
          onClick: () => { setTab(Tabs.Address) },
        },
      ]}
    />
  );
}