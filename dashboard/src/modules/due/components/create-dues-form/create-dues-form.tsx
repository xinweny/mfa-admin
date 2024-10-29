'use client';

import { useForm, useFieldArray } from 'react-hook-form';

import { CreateDuesSchema } from './schema';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection } from '@/core/form/components/form-section';

export function CreateDuesForm() {
  const form = useForm<CreateDuesSchema>();
  const { fields } = useFieldArray<CreateDuesSchema>({
    control: form.control,
    name: 'dues',
  });

  const onSubmit = async () => {

  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        
      </FormSection>
    </DashboardForm>
  );
}