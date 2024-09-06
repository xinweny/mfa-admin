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
    <>
      <div className="flex items-center gap-2">
        <DashboardFormField
          name={`${name ? `${name}.` : ''}firstName`}
          label="First Name"
          render={(field) => (
            <Input placeholder="Seizan" {...field} />
          )}
        />
        <DashboardFormField
          name={`${name ? `${name}.` : ''}lastName`}
          label="Last Name"
          render={(field) => (
            <Input placeholder="Suginomori" {...field} />
          )}
        />
      </div>
      <DashboardFormField
        name={`${name ? `${name}.` : ''}email`}
        label="Email"
        render={(field) => (
          <Input type="email" placeholder="example@gmail.com" {...field} />
        )}
      />
      <DashboardFormField
        name={`${name ? `${name}.` : ''}phoneNumber`}
        label="Phone Number"
        render={(field) => (
          <Input max={10} placeholder="0123456789" {...field} />
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
    </>
  );
}