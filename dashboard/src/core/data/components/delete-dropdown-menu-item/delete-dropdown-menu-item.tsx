import { Trash2Icon } from 'lucide-react';

import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
  DialogFooter,
  DialogClose,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';

import { RowDropdownMenuItem } from '../row-dropdown-menu-item';

interface DeleteDropdownMenuItemProps {
  triggerLabel: string;
  dialogTitle: string;
  onConfirm: () => void;
  cancelLabel?: string;
  confirmLabel?: string;
}

export function DeleteDropdownMenuItem({
  triggerLabel,
  dialogTitle,
  onConfirm,
  cancelLabel = 'Cancel',
  confirmLabel = 'Delete',
}: DeleteDropdownMenuItemProps) {


  return (
    <Dialog>
      <DialogTrigger asChild>
        <RowDropdownMenuItem
          icon={Trash2Icon}
          label={triggerLabel}
          className="text-destructive focus:bg-destructive"
        />
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>{dialogTitle}</DialogTitle>
        </DialogHeader>
        <DialogFooter>
          <DialogClose asChild>
            <Button variant="secondary">{cancelLabel}</Button>
          </DialogClose>
          <Button
            variant="destructive"
            onClick={onConfirm}
          >
            {confirmLabel}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}