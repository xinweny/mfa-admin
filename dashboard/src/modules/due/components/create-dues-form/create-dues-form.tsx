'use client';

import { useForm } from 'react-hook-form';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection, FormSectionContent } from '@/core/form/components/form-section';

export function CreateDuesForm() {
  const form = useForm();

  const onSubmit = async () => {

  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        a
      </FormSection>
    </DashboardForm>
  );
}