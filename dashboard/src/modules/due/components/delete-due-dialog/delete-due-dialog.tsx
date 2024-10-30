'use client';

import toast from 'react-hot-toast';

import { PaymentMethod, paymentMethodLabels } from '../../types';

import { handleError } from '@/core/api/utils';
import { formatMembersNames } from '@/modules/member/utils';

import { ConfirmationDialog } from '@/core/ui/components/confirmation-dialog';

import { deleteDue } from '../../actions';

interface DeleteDueDialogProps {
  id: string;
  year: number;
  members: {
    firstName: string;
    lastName: string;
  }[];
  paymentMethod: PaymentMethod;
  paymentDate: Date;
}

export function DeleteDueDialog({
  id,
  year,
  members,
  paymentMethod,
  paymentDate,
}: DeleteDueDialogProps) {
  const onDelete = async () => {
    try {
      await deleteDue(id);
      
      toast.success(`Receipt ${id} deleted successfully.`);
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <ConfirmationDialog
      title="Delete Receipt"
      description={`Are you sure you want to delete the ${year} ${paymentMethodLabels[paymentMethod]} payment from ${formatMembersNames(members)}?`}
      onConfirm={onDelete}
    />
  );
}