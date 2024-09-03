import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

interface MembershipRowDropdownMenuProps {
  id: string;
}

export function MembershipRowDropdownMenu({
  id,
}: MembershipRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={id}
        label="Copy Membership ID"
        message="Membership ID copied."
      />
    </RowDropdownMenu>
  );
}