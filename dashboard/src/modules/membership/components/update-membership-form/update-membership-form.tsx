'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { GetMembershipResponse, MembershipType } from '../../types';

import {
  updateMembershipSchemaResolver,
  UpdateMembershipSchema,
} from './schema';

import { handleError } from '@/core/api/utils';

import { updateMembership } from '../../actions';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection, FormSectionHeader } from '@/core/form/components/form-section';
import { MembershipFormFields } from '../membership-form-fields';

interface UpdateMembershipFormProps {
  membership: GetMembershipResponse;
}

export function UpdateMembershipForm({
  membership,
}: UpdateMembershipFormProps) {
  const form = useForm<UpdateMembershipSchema>({
    defaultValues: {
      membershipType: membership.membershipType,
      startDate: new Date(membership.startDate),
    },
    resolver: updateMembershipSchemaResolver,
  });

  const onSubmit = async (data: UpdateMembershipSchema) => {
    try {
      if (data.membershipType == MembershipType.Single) {
        form.setError('membershipType', {
          message: 'Cannot change to single membership with more than 1 family member. Please remove additional members.'
        });
        return;
      }

      await updateMembership(membership.id, data);

      toast.success('Membership updated successfully.');
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit} submitLabel="Update Membership">
      <FormSection>
        <FormSectionHeader>Membership</FormSectionHeader>
        <MembershipFormFields />
      </FormSection>
    </DashboardForm>
  )
}