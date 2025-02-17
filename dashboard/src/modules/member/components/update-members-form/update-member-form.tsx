'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { MemberSchema, memberSchemaResolver } from '../member-form-fields';

import { handleError } from '@/core/api/utils';

import { DashboardForm } from '@/components/form/dashboard-form';
import { FormSection } from '@/components/form/form-section';

import { MemberFormFields } from '../member-form-fields';
import { DeleteMemberButton } from '../delete-member-button';
import { GetMembershipResponse } from '@/modules/membership/types';

import { updateMember } from '../../actions';

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
    try {
      await updateMember(member.id, membershipId, data);

      toast.success('Member details updated successfully.');
      form.reset(data);
    } catch (err) {
      handleError(err);
    }
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