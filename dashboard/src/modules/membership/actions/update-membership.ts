'use server';

import { revalidatePath } from 'next/cache';

import { UpdateMembershipRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const updateMembership = async (id: string, req: UpdateMembershipRequest) => {
  const res = await mfaApiFetch(
    `memberships/${id}`,
    {
      method: 'PUT',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${id}`);
};