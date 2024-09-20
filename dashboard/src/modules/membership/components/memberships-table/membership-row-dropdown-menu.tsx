'use client';

import { useRouter } from 'next/navigation';
import { Edit3Icon } from 'lucide-react';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { RowDropdownMenuItem } from '@/core/data/components/row-dropdown-menu-item';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import {
  DeleteDropdownMenuItem,
} from '@/core/data/components/delete-dropdown-menu-item';

interface MembershipRowDropdownMenuProps {
  membershipId: string;
}

export function MembershipRowDropdownMenu({
  membershipId,
}: MembershipRowDropdownMenuProps) {
  const router = useRouter();

  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={membershipId}
        label="Copy Membership ID"
        message="Membership ID copied."
      />
      <RowDropdownMenuItem
        icon={Edit3Icon}
        label="Update Membership"
        onClick={() => {
          router.push(`/dashboard/memberships/edit?id=${membershipId}`);
        }}
      />
      <DeleteDropdownMenuItem
        triggerLabel="Delete Membership"
        dialogTitle="Delete Membership"
        onConfirm={() => {}}
      />
    </RowDropdownMenu>
  );
}