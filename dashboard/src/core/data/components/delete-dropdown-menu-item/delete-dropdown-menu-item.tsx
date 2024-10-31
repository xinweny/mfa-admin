import { Trash2Icon } from 'lucide-react';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface DeleteDropdownMenuItemProps {
  label: string;
  onClick: () => void;
}

export function DeleteDropdownMenuItem({
  label,
  onClick,
}: DeleteDropdownMenuItemProps) {
  return (
    <RowDropdownMenuItem
      icon={Trash2Icon}
      label={label}
      className="text-destructive focus:bg-destructive"
      onClick={onClick}
    />
  );
}