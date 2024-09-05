'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { Province } from '@/modules/address/types';
import { membershipTypeLabels } from '../../types';

import { createMembershipSchema, CreateMembershipSchema } from './schema';

import {
  DashboardForm,
  DashboardFormTitle,
} from '@/core/form/components/dashboard-form';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';


export function CreateMembershipForm() {
  const form = useForm<CreateMembershipSchema>({
    defaultValues: {
      membershipType: undefined,
      address: {
        line1: undefined,
        line2: undefined,
        city: undefined,
        postalCode: undefined,
        province: Province.ON,
      },
      members: [],
    },
    resolver: zodResolver(createMembershipSchema),
  });

  const onSubmit = (data: CreateMembershipSchema) => {

  };

  return (
    <DashboardForm
      form={form}
      onSubmit={onSubmit}
    >
      <DashboardFormTitle title="Create Membership" />
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
      />
    </DashboardForm>
  );
}