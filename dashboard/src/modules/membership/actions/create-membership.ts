'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { CreateMembershipRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const createMembership = async (req: CreateMembershipRequest) => {
  const res = await mfaApiFetch(
    'memberships',
    {
      method: 'POST',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  redirect(`/dashboard/memberships/${data.data.id}`);
};