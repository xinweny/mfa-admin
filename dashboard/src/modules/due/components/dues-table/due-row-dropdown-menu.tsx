import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

interface DueRowDropdownMenuProps {
 dueId: string;
}

export function DueRowDropdownMenu({
  dueId,
}: DueRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={dueId}
        label="Copy Due ID"
        message="Due ID copied."
      />
    </RowDropdownMenu>
  );
}