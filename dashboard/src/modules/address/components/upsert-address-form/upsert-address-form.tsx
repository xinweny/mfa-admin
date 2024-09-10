import { useForm } from 'react-hook-form';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection } from '@/core/form/components/form-section';

import { AddressFormFields } from '../address-form-fields';
import { Address } from '../../types';

interface UpsertAddressFormProps {
  membershipId: string;
  address: Address | null;
}

export function UpsertAddressForm({
  membershipId,
  address,
}: UpsertAddressFormProps) {
  const form = useForm();

  const onSubmit = () => {
    
  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        <AddressFormFields name="address" />
      </FormSection>
    </DashboardForm>
  );
}