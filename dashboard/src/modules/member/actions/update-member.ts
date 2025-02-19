'use server';

import { revalidatePath } from 'next/cache';

import { UpdateMemberRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const updateMember = async (
  id: string,
  membershipId: string,
  req: UpdateMemberRequest
) => {
  const res = await mfaApiFetch(
    `members/${id}`,
    {
      method: 'PUT',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/members');
};