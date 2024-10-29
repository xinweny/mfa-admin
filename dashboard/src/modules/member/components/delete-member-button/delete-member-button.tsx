import toast from 'react-hot-toast';

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

import { handleError } from '@/core/api/utils';

import { deleteMember } from '../../actions';

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
  const onDelete = async () => {
    try {
      await deleteMember(member.id);

      toast.success('Member deleted successfully.');
    } catch (err) {
      handleError(err);
    }
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
          <DialogDescription>{`Are you sure you want to delete ${member.firstName} ${member.lastName}? This will remove all associated hosting/delegation history and board positions.`}</DialogDescription>
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