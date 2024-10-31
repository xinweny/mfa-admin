'use server';

import { revalidatePath } from 'next/cache';

import { UpdateAddressRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const updateAddress = async (membershipId: string, req: UpdateAddressRequest) => {
  const res = await mfaApiFetch(
    `memberships/${membershipId}/address`,
    {
      method: 'PUT',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${membershipId}`);
};