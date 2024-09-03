import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

interface MemberRowDropdownMenuProps {
  id: string;
}

export function MemberRowDropdownMenu({
  id,
}: MemberRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={id}
        label="Copy Member ID"
        message="Member ID copied."
      />
    </RowDropdownMenu>
  );
}