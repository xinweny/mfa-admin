'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import toast from 'react-hot-toast';

import { GetMembershipResponse, MembershipType } from '../../types';
import { membershipTypeLabels } from '../../types';

import { updateMembershipSchema, UpdateMembershipSchema } from './schema';

import { handleError } from '@/core/api/utils';

import { updateMembership } from '../../actions';

import { DashboardForm, DashboardFormTitle } from '@/core/form/components/dashboard-form';
import { FormSection, FormSectionContent } from '@/core/form/components/form-section';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';
import { FormInputDate } from '@/core/form/components/form-input-date';

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
    resolver: zodResolver(updateMembershipSchema),
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
    <DashboardForm form={form} onSubmit={onSubmit}>
      <DashboardFormTitle title="Edit Membership" />
      <FormSection>
        <FormSectionContent>
          <DashboardFormField
            name="membershipType"
            label="Membership Type"
            render={(field) => (
              <FormInputSelect
                value={field.value}
                onChange={(value) => {
                  field.onChange(+value);
                }}
                options={Object.entries(membershipTypeLabels).map(([k, v]) => ({
                  label: v,
                  value: k,
                }))}
                placeholder="Select membership type"
              />
            )}
            className="flex-grow"
          />
          <DashboardFormField
            name="startDate"
            label="Start Date"
            render={(field) => (
              <FormInputDate
                value={field.value as Date}
                onChange={field.onChange}
                toYear={new Date().getFullYear() + 1}
              />
            )}
            className="flex-grow"
          />
        </FormSectionContent>
      </FormSection>
    </DashboardForm>
  )
}