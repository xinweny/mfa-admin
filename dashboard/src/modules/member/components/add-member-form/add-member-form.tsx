'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';
import { useRouter } from 'next/navigation';

import { handleError } from '@/core/api/utils';

import { DashboardForm } from '@/components/form/dashboard-form';
import { MemberFormFields, MemberSchema, memberSchemaResolver } from '../member-form-fields';
import { FormSection, FormSectionHeader } from '@/components/form/form-section';
import { createMember } from '../../actions';

interface AddMemberFormProps {
  membershipId: string;
}

export function AddMemberForm({
  membershipId,
}: AddMemberFormProps) {
  const router = useRouter();

  const form = useForm<MemberSchema>({
    defaultValues: {
      firstName: undefined,
      lastName: undefined,
      email: undefined,
      phoneNumber: undefined,
      joinedDate: new Date(),
    },
    resolver: memberSchemaResolver,
  });

  const onSubmit = async (data: MemberSchema) => {
    try {
      await createMember({
        membershipId,
        ...data,
      });

      toast.success('Member details updated successfully.');
      form.reset(data);
      router.refresh();
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        <FormSectionHeader>Add Member</FormSectionHeader>
        <MemberFormFields />
      </FormSection>
    </DashboardForm>
  );
}