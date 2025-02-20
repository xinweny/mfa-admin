import {
  DialogContent,
  DialogTitle,
  DialogDescription,
  DialogHeader,
  DialogFooter,
  DialogClose,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';

interface AlertDialogProps {
  title: string;
  description?: React.ReactNode;
  onConfirm: () => void;
  cancelLabel?: string;
  confirmLabel?: string;
}

export function AlertDialog({
  title,
  onConfirm,
  cancelLabel = 'Cancel',
  confirmLabel = 'Confirm',
  description,
}: AlertDialogProps) {
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