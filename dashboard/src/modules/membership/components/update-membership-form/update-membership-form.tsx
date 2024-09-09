'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import toast from 'react-hot-toast';

import { GetMembershipResponse } from '../../types';

import { updateMembershipSchema, UpdateMembershipSchema } from './schema';

import { updateMembership } from '../../actions';

import { DashboardForm, DashboardFormTitle } from '@/core/form/components/dashboard-form';

interface UpdateMembershipFormProps {
  membership: GetMembershipResponse;
}

export function UpdateMembershipForm({
  membership,
}: UpdateMembershipFormProps) {
  const form = useForm<UpdateMembershipSchema>({
    defaultValues: {
      membershipType: membership.membershipType,
      startDate: new Date(membership.startDate),
    },
    resolver: zodResolver(updateMembershipSchema),
  });

  const onSubmit = async (data: UpdateMembershipSchema) => {
    const res = await updateMembership(membership.id, data);

    res.error
      ? toast.error('Unable to update membership.')
      : toast.success('Membership updated successfully.');
  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <DashboardFormTitle title="Edit Membership" />
    </DashboardForm>
  )
}