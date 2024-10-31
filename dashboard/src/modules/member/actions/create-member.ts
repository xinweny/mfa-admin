'use server';

import { revalidatePath } from 'next/cache';

import { mfaApiFetch } from '@/core/api/utils';

import { ErrorResponse } from '@/core/api/types';
import { CreateMemberRequest } from '../types';

export const createMember = async (
  req: CreateMemberRequest
) => {
  const res = await mfaApiFetch(
    'members',
    {
      method: 'POST',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/members');
};