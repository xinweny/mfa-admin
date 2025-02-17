'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';
import { useRouter } from 'next/navigation';

import { PaymentMethod, paymentMethodOptions } from '../../types';
import { MembershipType } from '@/modules/membership/types';

import { UpdateDueSchema, updateDueSchemaResolver } from './schema';

import { formatHtmlDateString } from '@/utils';
import { handleError } from '@/core/api/utils';

import { DialogContent } from '@/components/ui/dialog';
import { Input } from '@/components/ui/input';

import { DashboardForm, DashboardFormTitle } from '@/components/form/dashboard-form';
import { DashboardFormField } from '@/components/form/dashboard-form-field';
import { FormInputSelect } from '@/components/form/form-input-select';
import { formatMemberNames } from '@/modules/member/utils';
import { MembershipTypeBadge } from '@/modules/membership/components/membership-type-badge';

import { updateDue } from '../../actions';

interface EditDueFormDialogProps {
  due: {
    id: string;
    year: number;
    paymentMethod: PaymentMethod;
    paymentDate?: Date;
  };
  members: {
    firstName: string;
    lastName: string;
  }[];
  membershipType: MembershipType;
}

export function EditDueFormDialog({
  due: {
    id,
    year,
    paymentMethod,
    paymentDate,
  },
  members,
  membershipType,
}: EditDueFormDialogProps) {
  const router = useRouter();

  const form = useForm<UpdateDueSchema>({
    defaultValues: {
      year,
      paymentMethod,
      paymentDate,
    },
    resolver: updateDueSchemaResolver,
  });

  const onSubmit = async (data: UpdateDueSchema) => {
    try {
      await updateDue(id, data);

      toast.success(`Receipt ${id} updated successfully.`);
      router.refresh();
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <DialogContent>
      <DashboardForm form={form} onSubmit={onSubmit}>
        <DashboardFormTitle title="Edit Receipt" />
        <div className="flex items-center justify-between">
          <span>{formatMemberNames(members)}</span>
          <MembershipTypeBadge membershipType={membershipType} />
        </div>
        <DashboardFormField
          name="year"
          label="Year"
          render={(field) => (
            <Input
              type="number"
              value={field.value}
              onChange={field.onChange}
            />
          )}
        />
        <DashboardFormField
          name="paymentMethod"
          label="Payment Method"
          render={(field) => (
            <FormInputSelect
              value={field.value.toString()}
              onChange={v => { field.onChange(+v); }}
              options={paymentMethodOptions}
            />
          )}
        />
        <DashboardFormField
          name="paymentDate"
          label="Payment Date"
          render={(field) => (
            <Input
              type="date"
              value={formatHtmlDateString(field.value)}
              onChange={field.onChange}
            />
          )}
        />
      </DashboardForm>
    </DialogContent>
  );
}