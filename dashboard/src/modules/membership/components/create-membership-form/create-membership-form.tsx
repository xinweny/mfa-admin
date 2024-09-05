'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { membershipTypeLabels } from '../../types';

import { createMembershipSchema, CreateMembershipSchema } from './schema';

import {
  DashboardForm,
  DashboardFormTitle,
} from '@/core/form/components/dashboard-form';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';
import { AddressFormFields } from '@/modules/address/components/address-form-fields';
import { FormInputDate } from '@/core/form/components/form-input-date';
import { FormSectionAccordion } from '@/core/form/components/form-section-accordion';

export function CreateMembershipForm() {
  const form = useForm<CreateMembershipSchema>({
    defaultValues: {
      membershipType: undefined,
      address: undefined,
      startDate: new Date(),
      members: [{
        firstName: undefined,
        lastName: undefined,
        email: undefined,
        phoneNumber: undefined,
        joinedDate: new Date(),
      }],
    },
    resolver: zodResolver(createMembershipSchema),
  });

  const onSubmit = (data: CreateMembershipSchema) => {
    console.log(data);
  };

  return (
    <DashboardForm
      form={form}
      onSubmit={onSubmit}
    >
      <DashboardFormTitle title="Create Membership" />
      <fieldset className="flex gap-2">
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
        <DashboardFormField
          name="membershipType"
          label="Membership Type"
          render={(field) => (
            <FormInputSelect
              value={field.value}
              onChange={field.onChange}
              options={Object.entries(membershipTypeLabels).map(([k, v]) => ({
                label: v,
                value: k,
              }))}
              placeholder="Select membership type"
            />
          )}
          className="flex-grow"
        />
      </fieldset>
      <FormSectionAccordion label="Address" name="address">
        <AddressFormFields name="address" />
      </FormSectionAccordion>

    </DashboardForm>
  );
}