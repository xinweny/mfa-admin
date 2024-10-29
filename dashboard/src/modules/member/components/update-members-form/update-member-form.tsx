'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { MemberSchema, memberSchemaResolver } from '../member-form-fields';

import { handleError } from '@/core/api/utils';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection } from '@/core/form/components/form-section';

import { MemberFormFields } from '../member-form-fields';
import { DeleteMemberButton } from '../delete-member-button';
import { GetMembershipResponse } from '@/modules/membership/types';

interface UpdateMemberFormProps {
  member: GetMembershipResponse['members'][0];
  membershipId: string;
}

export function UpdateMemberForm({
  member,
  membershipId,
}: UpdateMemberFormProps) {
  const form = useForm<MemberSchema>({
    defaultValues: {
      firstName: member.firstName,
      lastName: member.lastName,
      email: member.email,
      phoneNumber: member.phoneNumber,
      joinedDate: new Date(member.joinedDate),
    },
    resolver: memberSchemaResolver,
  });

  const onSubmit = async (data: MemberSchema) => {
  };

  return (
    <div>
      <DashboardForm form={form} onSubmit={onSubmit} submitLabel="Update Member" className="mb-2">
        <FormSection>
          <MemberFormFields />
        </FormSection>
      </DashboardForm>
      <DeleteMemberButton member={member} />
    </div>
  );
}