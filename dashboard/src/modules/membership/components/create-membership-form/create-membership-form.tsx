'use client';

import { useForm } from 'react-hook-form';
import toast from 'react-hot-toast';

import { MembershipType } from '../../types';
import { Province } from '@/modules/address/types';

import {
  createMembershipSchemaResolver,
  CreateMembershipSchema,
} from './schema';

import { handleError } from '@/core/api/utils';

import {
  DashboardForm,
  DashboardFormTitle,
} from '@/core/form/components/dashboard-form';

import { MembersFormSection } from './components/members-form-section';
import { AddressFormSection } from './components/address-form-section';
import { MembershipFormSection } from './components/membership-form-section';

import { createMembership } from '../../actions';

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
    resolver: createMembershipSchemaResolver,
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
      submitLabel="Create Membership"
    >
      <DashboardFormTitle title="Create Membership" />
      <MembershipFormSection />
      <AddressFormSection />
      <MembersFormSection />
    </DashboardForm>
  );
}