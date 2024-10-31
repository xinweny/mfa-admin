'use server';

import { revalidatePath } from 'next/cache';

import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const deleteAddress = async (membershipId: string) => {
  const res = await mfaApiFetch(
    `memberships/${membershipId}/address`,
    {
      method: 'DELETE',
      body: undefined,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${membershipId}`);
};