import { Trash2Icon } from 'lucide-react';

import {
  DialogTrigger,
} from '@/components/ui/dialog';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface DeleteDropdownMenuItemProps {
  label: string;
}

export function DeleteDropdownMenuItem({
  label,
}: DeleteDropdownMenuItemProps) {
  return (
    <DialogTrigger asChild>
      <RowDropdownMenuItem
        icon={Trash2Icon}
        label={label}
        className="text-destructive focus:bg-destructive"
      />
    </DialogTrigger>
  );
}