import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

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
    </RowDropdownMenu>
  );
}