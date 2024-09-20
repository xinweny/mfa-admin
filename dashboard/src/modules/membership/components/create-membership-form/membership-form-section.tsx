import { FormSection, FormSectionHeader } from '@/core/form/components/form-section';

import { MembershipFormFields } from '../membership-form-fields';

export function MembershipFormSection() {
  return (
    <FormSection>
      <FormSectionHeader>Membership</FormSectionHeader>
      <MembershipFormFields />
    </FormSection>
  );
}