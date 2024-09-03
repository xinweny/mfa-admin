import { toast } from 'react-hot-toast';
import { CopyIcon } from 'lucide-react';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface CopyIdDropdownMenuItemProps {
  id: string;
  label?: string;
  message?: string;
}

export function CopyIdDropdownMenuItem({
  id,
  label = 'Copy ID',
  message = 'ID copied.',
}: CopyIdDropdownMenuItemProps) {
  return (
    <RowDropdownMenuItem
      onClick={() => {
        navigator.clipboard.writeText(id);
        toast.success(message);
      }}
      icon={CopyIcon}
      label={label}
    />
  );
}