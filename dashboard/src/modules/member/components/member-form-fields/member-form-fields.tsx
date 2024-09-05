import { Input } from '@/components/ui/input';

import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputDate } from '@/core/form/components/form-input-date';

interface MemberFormFieldsProps {
  name?: string;
}

export function MemberFormFields({
  name,
}: MemberFormFieldsProps) {
  return (
    <fieldset>
      <DashboardFormField
        name={`${name ? `${name}.` : ''}firstName`}
        label="First Name"
        render={(field) => (
          <Input {...field} />
        )}
      />
      <DashboardFormField
        name={`${name ? `${name}.` : ''}lastName`}
        label="Last Name"
        render={(field) => (
          <Input {...field} />
        )}
      />
      <DashboardFormField
        name={`${name ? `${name}.` : ''}email`}
        label="Email"
        render={(field) => (
          <Input type="email" {...field} />
        )}
      />
      <DashboardFormField
        name={`${name ? `${name}.` : ''}phoneNumber`}
        label="Phone Number"
        render={(field) => (
          <Input  max={10} {...field} />
        )}
      />
      <DashboardFormField
        name={`${name ? `${name}.` : ''}joinedDate`}
        label="Joined Date"
        render={(field) => (
          <FormInputDate
            value={field.value}
            onChange={field.onChange}
          />
        )}
      />
    </fieldset>
  );
}