import { toast } from 'react-hot-toast';

import { DropdownMenuItem } from '@/components/ui/dropdown-menu';

interface CopyIdDropdownMenuItemProps {
  id: string;
  label?: string;
}

export function CopyIdDropdownMenuItem({
  id,
  label = 'Copy ID',
}: CopyIdDropdownMenuItemProps) {
  return (
    <DropdownMenuItem
      onClick={() => {
        navigator.clipboard.writeText(id);
        toast.success('ID copied.');
      }}
    >
      {label}
    </DropdownMenuItem>
  );
}