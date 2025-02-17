'use client';

import toast from 'react-hot-toast';
import { format } from 'date-fns';

import { PaymentMethod, paymentMethodLabels } from '../../types';

import { handleError } from '@/core/api/utils';
import { formatMemberNames } from '@/modules/member/utils';

import { AlertDialog } from '@/components/ui/alert-dialog';

import { deleteDue } from '../../actions';

interface DeleteDueDialogProps {
  due: {
    id: string;
    paymentMethod: PaymentMethod;
    paymentDate?: Date;
    year: number;
  };
  members: {
    firstName: string;
    lastName: string;
  }[];
}

export function DeleteDueDialog({
  members,
  due: {
    id,
    year,
    paymentMethod,
    paymentDate,
  }
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
    <AlertDialog
      title="Delete Receipt"
      description={`Are you sure you want to delete the ${year} ${paymentMethodLabels[paymentMethod]} payment from ${formatMemberNames(members)}${paymentDate ? ` on ${format(paymentDate, 'dd/LL/yyyy')}` : ''}?`}
      onConfirm={onDelete}
    />
  );
}