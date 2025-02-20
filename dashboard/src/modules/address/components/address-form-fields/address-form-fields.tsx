import { Input } from '@/components/ui/input';

import { DashboardFormField } from '@/components/form/dashboard-form-field';
import { FormInputSelect } from '@/components/form/form-input-select';
import { provinceLabels } from '../../types';
import { FormSectionContent } from '@/components/form/form-section';

interface AddressFormFieldsProps {
  name?: string;
}

export function AddressFormFields({
  name = '',
}: AddressFormFieldsProps) {
  return (
    <FormSectionContent className="flex gap-2">
      <DashboardFormField
        name={`${name}line1`}
        label="Line 1"
        render={(field) => (
          <Input placeholder="300 City Centre Dr" {...field} />
        )}
      />
      <DashboardFormField
        name={`${name}line2`}
        label="Line 2"
        render={(field) => (
          <Input {...field} />
        )}
      />
      <DashboardFormField
        name={`${name}city`}
        label="City"
        render={(field) => (
          <Input
            placeholder="Mississauga"
            {...field}
          />
        )}
      />
      <DashboardFormField
        name={`${name}postalCode`}
        label="Postal Code"
        render={(field) => (
          <Input
            placeholder="L5B 3C1"
            {...field}
          />
        )}
      />
      <DashboardFormField
        name={`${name}province`}
        label="Province"
        render={(field) => (
          <FormInputSelect
            value={field.value}
            onChange={field.onChange}
            options={Object.entries(provinceLabels).map(([k, v]) => ({
              label: v,
              value: k,
            }))}
            placeholder="Select Province"
          />
        )}
      />
    </FormSectionContent>
  );
}