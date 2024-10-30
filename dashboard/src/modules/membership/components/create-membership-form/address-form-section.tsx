import { useFieldArray } from 'react-hook-form';
import { MinusIcon, PlusIcon } from 'lucide-react';

import { useCreateMembershipFormContext } from './schema';

import {
  FormSection,
  FormSectionHeader,
  FormSectionHeaderButton,
} from '@/core/form/components/form-section';

import { AddressFormFields } from '@/modules/address/components/address-form-fields';
import { Province } from '@/modules/address/types';

export function AddressFormSection() {
  const { control } = useCreateMembershipFormContext();
  const { fields, append, remove } = useFieldArray({
    control,
    name: 'address',
  });

  return (
    <FormSection>
      <FormSectionHeader className="flex justify-between items-center">
        <span>Address</span>
        <FormSectionHeaderButton
          icon={fields.length === 0 ? PlusIcon : MinusIcon}
          label={`${fields.length === 0 ? 'Add' : 'Remove'} Address`}
          onClick={() => {
            fields.length === 0
              ? append({
                line1: '',
                line2: undefined,
                city: '',
                postalCode: '',
                province: Province.ON,
              })
              : remove(0);
          }}
        />
      </FormSectionHeader>
      {fields.map((field, index) => (
        <AddressFormFields key={field.id} name={`address.${index}.`} />
      ))}
    </FormSection>
  );
}