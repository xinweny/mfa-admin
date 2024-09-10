import { useForm } from 'react-hook-form';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection } from '@/core/form/components/form-section';

import { UpsertAddressSchema, upsertAddressSchemaResolver } from './schema';

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
  const form = useForm<UpsertAddressSchema>({
    defaultValues: {
      line1: address?.line1 || undefined,
      line2: address?.line2 || undefined,
      city: address?.city || undefined,
      postalCode: address?.postalCode || undefined,
      province: address?.province || undefined,
    },
    resolver: upsertAddressSchemaResolver,
  });

  const onSubmit = (data: UpsertAddressSchema) => {

  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        <AddressFormFields name="address" />
      </FormSection>
    </DashboardForm>
  );
}