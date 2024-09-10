import { membershipTypeLabels } from '../../types';

import { FormSectionContent } from '@/core/form/components/form-section';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';
import { FormInputDate } from '@/core/form/components/form-input-date';

export function MembershipFormFields() {
  return (
    <FormSectionContent>
      <DashboardFormField
        name="membershipType"
        label="Membership Type"
        render={(field) => (
          <FormInputSelect
            value={field.value}
            onChange={(value) => {
              field.onChange(+value);
            }}
            options={Object.entries(membershipTypeLabels).map(([k, v]) => ({
              label: v,
              value: k,
            }))}
            placeholder="Select membership type"
          />
        )}
        className="flex-grow"
      />
      <DashboardFormField
        name="startDate"
        label="Start Date"
        render={(field) => (
          <FormInputDate
            value={field.value as Date}
            onChange={field.onChange}
            toYear={new Date().getFullYear() + 1}
          />
        )}
        className="flex-grow"
      />
    </FormSectionContent>
  );
}