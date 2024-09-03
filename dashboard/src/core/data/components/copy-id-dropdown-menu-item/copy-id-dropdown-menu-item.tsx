import { toast } from 'react-hot-toast';
import { CopyIcon } from 'lucide-react';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface CopyIdDropdownMenuItemProps {
  id: string;
  label?: string;
}

export function CopyIdDropdownMenuItem({
  id,
  label = 'Copy ID',
}: CopyIdDropdownMenuItemProps) {
  return (
    <RowDropdownMenuItem
      onClick={() => {
        navigator.clipboard.writeText(id);
        toast.success('ID copied.');
      }}
      icon={CopyIcon}
      label={label}
    />
  );
}