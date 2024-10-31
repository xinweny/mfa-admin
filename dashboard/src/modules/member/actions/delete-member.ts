'use server';

import { revalidatePath } from 'next/cache';

import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const deleteMember = async (memberId: string) => {
  const res = await mfaApiFetch(
    `members/${memberId}`,
    {
      method: 'DELETE',
      body: undefined,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/members');
};