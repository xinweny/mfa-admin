import { Input } from '@/components/ui/input';

import { DashboardFormField } from '@/components/form/dashboard-form-field';
import { FormInputDate } from '@/components/form/form-input-date';

interface MemberFormFieldsProps {
  name?: string;
}

export function MemberFormFields({
  name,
}: MemberFormFieldsProps) {
  const prefix = name ? `${name}.` : '';

  return (
    <>
      <div className="flex items-center gap-2">
        <DashboardFormField
          name={`${prefix}firstName`}
          label="First Name"
          render={(field) => (
            <Input placeholder="Seizan" {...field} />
          )}
        />
        <DashboardFormField
          name={`${prefix}lastName`}
          label="Last Name"
          render={(field) => (
            <Input placeholder="Suginomori" {...field} />
          )}
        />
      </div>
      <DashboardFormField
        name={`${prefix}email`}
        label="Email"
        render={(field) => (
          <Input type="email" placeholder="example@gmail.com" {...field} />
        )}
      />
      <DashboardFormField
        name={`${prefix}phoneNumber`}
        label="Phone Number"
        render={(field) => (
          <Input max={10} placeholder="0123456789" {...field} />
        )}
      />
      <DashboardFormField
        name={`${prefix}joinedDate`}
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