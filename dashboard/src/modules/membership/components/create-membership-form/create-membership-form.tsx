'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import toast from 'react-hot-toast';

import { MembershipType, membershipTypeLabels } from '../../types';
import { Province } from '@/modules/address/types';

import { createMembershipSchema, CreateMembershipSchema } from './schema';

import {
  DashboardForm,
  DashboardFormTitle,
} from '@/core/form/components/dashboard-form';
import { DashboardFormField } from '@/core/form/components/dashboard-form-field';
import { FormInputSelect } from '@/core/form/components/form-input-select';
import { FormInputDate } from '@/core/form/components/form-input-date';
import {
  FormSection,
  FormSectionHeader,
  FormSectionContent,
} from '@/core/form/components/form-section';

import { MembersFormSection } from './members-form-section';
import { AddressFormSection } from './address-form-section';

import { createMembership } from '../../actions';
import { handleError } from '@/core/api/utils';

export function CreateMembershipForm() {
  const form = useForm<CreateMembershipSchema>({
    defaultValues: {
      membershipType: MembershipType.Single,
      address: [{
        line1: '',
        line2: undefined,
        city: '',
        postalCode: '',
        province: Province.ON,
      }],
      startDate: new Date(),
      members: [{
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        joinedDate: new Date(),
      }],
    },
    resolver: zodResolver(createMembershipSchema),
  });

  const onSubmit = async (data: CreateMembershipSchema) => {
    try {
      await createMembership({
        membershipType: data.membershipType,
        startDate: data.startDate,
        address: data.address.length === 1
          ? {
            line1: data.address[0].line1,
            line2: data.address[0].line2 || null,
            city: data.address[0].city,
            postalCode: data.address[0].postalCode,
            province: data.address[0].province,
          }
          : null,
        members: data.members.map(m => ({
          firstName: m.firstName,
          lastName: m.lastName,
          email: m.email,
          phoneNumber: m.phoneNumber || null,
          joinedDate: m.joinedDate,
        })),
      });

      toast.success('Membership created successfully.');
    } catch (err) {
      handleError(err);
    }
  };

  return (
    <DashboardForm
      form={form}
      onSubmit={onSubmit}
    >
      <DashboardFormTitle title="Create Membership" />
      <FormSection>
        <FormSectionHeader>Membership</FormSectionHeader>
        <FormSectionContent>
          <DashboardFormField
            name="membershipType"
            label="Membership Type"
            render={(field) => (
              <FormInputSelect
                value={field.value}
                onChange={(value) => {
                  field.onChange(+value);
                  form.resetField('members');
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
      </FormSection>
      <AddressFormSection />
      <MembersFormSection />
    </DashboardForm>
  );
}