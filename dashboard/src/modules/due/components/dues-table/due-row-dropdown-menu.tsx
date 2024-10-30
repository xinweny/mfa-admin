import { IdCard } from 'lucide-react';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import { DeleteDropdownMenuItem } from '@/core/data/components/delete-dropdown-menu-item';
import { LinkDropdownMenuItem } from '@/core/data/components/link-dropdown-menu-item';

import { DeleteDueDialog } from '../delete-due-dialog';

interface DueRowDropdownMenuProps {
 dueId: string;
 membershipId: string;
}

export function DueRowDropdownMenu({
  dueId,
  membershipId,
}: DueRowDropdownMenuProps) {
  return (
    <RowDropdownMenu dialog={<DeleteDueDialog id={dueId} />}>
      <CopyIdDropdownMenuItem
        id={dueId}
        label="Copy Receipt ID"
        message="Receipt ID copied."
      />
      <LinkDropdownMenuItem
        href={`/dashboard/memberships/${membershipId}`}
        icon={IdCard}
        label="View Membership"
      />
      <DeleteDropdownMenuItem
        label="Delete Receipt"
      />
    </RowDropdownMenu>
  );
}