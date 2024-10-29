'use client';

import { Edit3Icon } from 'lucide-react';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import { LinkDropdownMenuItem } from '@/core/data/components/link-dropdown-menu-item';

interface MembershipRowDropdownMenuProps {
  membershipId: string;
}

export function MembershipRowDropdownMenu({
  membershipId,
}: MembershipRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={membershipId}
        label="Copy Membership ID"
        message="Membership ID copied."
      />
      <LinkDropdownMenuItem
        href={`/dashboard/memberships/edit?id=${membershipId}`}
        icon={Edit3Icon}
        label="Manage Membership"
      />
    </RowDropdownMenu>
  );
}