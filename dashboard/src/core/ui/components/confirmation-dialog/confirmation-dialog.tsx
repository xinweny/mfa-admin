import {
  DialogContent,
  DialogTitle,
  DialogDescription,
  DialogHeader,
  DialogFooter,
  DialogClose,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';

interface ConfirmationDialogProps {
  title: string;
  description?: string;
  onConfirm: () => void;
  cancelLabel?: string;
  confirmLabel?: string;
}

export function ConfirmationDialog({
  title,
  onConfirm,
  cancelLabel = 'Cancel',
  confirmLabel = 'Confirm',
  description,
}: ConfirmationDialogProps) {
  return (
    <DialogContent>
      <DialogHeader>
        <DialogTitle>{title}</DialogTitle>
        {description && (
          <DialogDescription>{description}</DialogDescription>
        )}
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
  )
}