import { useState } from 'react';
import { Edit3Icon, IdCard } from 'lucide-react';

import { PaymentMethod } from '../../types';
import { MembershipType } from '@/modules/membership/types';

import { Dialog } from '@/components/ui/dialog';

import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';
import { DeleteDropdownMenuItem } from '@/core/data/components/delete-dropdown-menu-item';
import { LinkDropdownMenuItem } from '@/core/data/components/link-dropdown-menu-item';
import { RowDropdownMenuItem } from '@/core/data/components/row-dropdown-menu-item';

import { DeleteDueDialog } from '../delete-due-dialog';
import { EditDueFormDialog } from '../edit-due-form-dialog';

interface DueRowDropdownMenuProps {
  due: {
    id: string;
    paymentMethod: PaymentMethod;
    paymentDate?: Date;
    membershipId: string;
    year: number;
  };
  members: {
    firstName: string;
    lastName: string;
  }[];
  membershipType: MembershipType;
}

export function DueRowDropdownMenu({
  due,
  members,
  membershipType,
}: DueRowDropdownMenuProps) {
  const [isEditDialogOpen, setIsEditDialogOpen] = useState<boolean>(false);
  const [isDeleteDialogOpen, setIsDeleteDialogOpen] = useState<boolean>(false);

  const { id, membershipId } = due;

  return (
    <>
      <RowDropdownMenu>
        <CopyIdDropdownMenuItem
          id={id}
          label="Copy Receipt ID"
          message="Receipt ID copied."
        />
        <LinkDropdownMenuItem
          href={`/dashboard/memberships/${membershipId}`}
          icon={IdCard}
          label="View Membership"
        />
        <RowDropdownMenuItem
          icon={Edit3Icon}
          label="Edit Receipt"
          onClick={() => { setIsEditDialogOpen(true); }}
        />
        <DeleteDropdownMenuItem
          label="Delete Receipt"
          onClick={() => { setIsDeleteDialogOpen(true); }}
        />
      </RowDropdownMenu>
      <Dialog open={isDeleteDialogOpen} onOpenChange={setIsDeleteDialogOpen}>
        <DeleteDueDialog
          due={due}
          members={members}
        />
      </Dialog>
      <Dialog open={isEditDialogOpen} onOpenChange={setIsEditDialogOpen}>
        <EditDueFormDialog
          members={members}
          due={due}
          membershipType={membershipType}
        />
      </Dialog>
    </>
  );
}