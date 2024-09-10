'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { UpsertAddressSchema, upsertAddressSchemaResolver } from './schema';

import { AddressFormFields } from '../address-form-fields';
import { Address } from '../../types';

import { handleError } from '@/core/api/utils';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection, FormSectionHeader } from '@/core/form/components/form-section';

import { createAddress, updateAddress } from '../../actions';

interface UpsertAddressFormProps {
  membershipId: string;
  address: Address | null;
}

export function UpsertAddressForm({
  membershipId,
  address,
}: UpsertAddressFormProps) {
  const defaultValues = {
    line1: address?.line1 || undefined,
    line2: address?.line2 || undefined,
    city: address?.city || undefined,
    postalCode: address?.postalCode || undefined,
    province: address?.province || undefined,
  };

  const form = useForm<UpsertAddressSchema>({
    defaultValues,
    resolver: upsertAddressSchemaResolver,
  });

  const onSubmit = async (data: UpsertAddressSchema) => {
    try {
      const addr = {
        ...data,
        line2: data.line2 || null,
      };

      if (address === null) {
        await createAddress(membershipId, addr);
        toast.success('Address added successfully');
      } else {
        await updateAddress(membershipId, addr);
      }
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <DashboardForm
      form={form}
      onSubmit={onSubmit}
      submitLabel={`${address ? 'Update' : 'Create'} Address`}
    >
      <FormSection>
        <FormSectionHeader>Address</FormSectionHeader>
        <AddressFormFields />
      </FormSection>
    </DashboardForm>
  );
}