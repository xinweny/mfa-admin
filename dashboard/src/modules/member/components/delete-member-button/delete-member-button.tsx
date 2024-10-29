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

interface DeleteDropdownMenuItemProps {
  member: {
    id: string;
    firstName: string;
    lastName: string;
  };
}

export function DeleteMemberButton({
  member,
}: DeleteDropdownMenuItemProps) {
  const onDelete = () => {

  };

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button
          className="w-full"
          variant="destructive"
        >
          Delete Member
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Delete Member</DialogTitle>
          <DialogDescription>{`Are you sure you want to delete ${member.firstName} ${member.lastName}? This action cannot be undone.`}</DialogDescription>
        </DialogHeader>
        <DialogFooter>
          <DialogClose asChild>
            <Button variant="secondary">Cancel</Button>
          </DialogClose>
          <Button
            variant="destructive"
            onClick={onDelete}
          >
            {`Delete ${member.firstName} ${member.lastName}`}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}