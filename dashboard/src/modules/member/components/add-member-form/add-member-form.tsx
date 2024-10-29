'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { handleError } from '@/core/api/utils';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { MemberFormFields, MemberSchema, memberSchemaResolver } from '../member-form-fields';
import { FormSection, FormSectionHeader } from '@/core/form/components/form-section';
import { createMember } from '../../actions';

interface AddMemberFormProps {
  membershipId: string;
}

export function AddMemberForm({
  membershipId,
}: AddMemberFormProps) {
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