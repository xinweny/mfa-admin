import { membershipTypeLabels } from '../../types';

import { FormSectionContent } from '@/core/form/components/form-section';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';
import { FormInputDate } from '@/core/form/components/form-input-date';
import { FormInputSwitch } from '@/core/form/components/form-input-switch';

interface MembershipFormFieldsProps {
  withArchived?: boolean;
}

export function MembershipFormFields({
  withArchived = false,
}: MembershipFormFieldsProps) {
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
      {withArchived && (
        <DashboardFormField
          name="isArchived"
          render={(field) => (
            <FormInputSwitch
              value={field.value as boolean}
              label="Archived"
              description="Archived memberships will be hidden from searches and statistics by default."
              onCheckedChange={field.onChange}
            />
          )}
          className="flex-grow"
        />
      )}
    </FormSectionContent>
  );
}