import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

interface MemberRowDropdownMenuProps {
  memberId: string;
}

export function MemberRowDropdownMenu({
  memberId,
}: MemberRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={memberId}
        label="Copy Member ID"
        message="Member ID copied."
      />
    </RowDropdownMenu>
  );
}