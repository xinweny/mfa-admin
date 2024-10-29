'use client';

import { useRouter } from 'next/navigation';
import { IdCard } from 'lucide-react';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import { RowDropdownMenuItem } from '@/core/data/components/row-dropdown-menu-item';

interface MemberRowDropdownMenuProps {
  memberId: string;
  membershipId: string;
}

export function MemberRowDropdownMenu({
  memberId,
  membershipId,
}: MemberRowDropdownMenuProps) {
  const router = useRouter();

  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={memberId}
        label="Copy Member ID"
        message="Member ID copied."
      />
      <RowDropdownMenuItem
        icon={IdCard}
        label="View Membership"
        onClick={() => {
          router.push(`/dashboard/memberships/${membershipId}`)
        }}
      />
    </RowDropdownMenu>
  );
}