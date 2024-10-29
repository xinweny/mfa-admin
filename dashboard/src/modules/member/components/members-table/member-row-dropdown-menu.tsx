'use client';

import { IdCard, Edit3 } from 'lucide-react';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import { LinkDropdownMenuItem } from '@/core/data/components/link-dropdown-menu-item';
import { UpdateMembershipTabs } from '@/modules/membership/state';

interface MemberRowDropdownMenuProps {
  memberId: string;
  membershipId: string;
}

export function MemberRowDropdownMenu({
  memberId,
  membershipId,
}: MemberRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={memberId}
        label="Copy Member ID"
        message="Member ID copied."
      />
      <LinkDropdownMenuItem
        href={`/dashboard/memberships/${membershipId}`}
        icon={IdCard}
        label="View Membership"
      />
      <LinkDropdownMenuItem
        href={`/dashboard/memberships/edit?id=${membershipId}&tab=${UpdateMembershipTabs.Members}`}
        icon={Edit3}
        label="Edit Details"
      />
    </RowDropdownMenu>
  );
}