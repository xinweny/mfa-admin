'use server';

import { revalidatePath } from 'next/cache';

import { CreateAddressRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const createAddress = async (membershipId: string, req: CreateAddressRequest) => {
  const res = await mfaApiFetch(
    `memberships/${membershipId}/address`,
    {
      method: 'POST',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${membershipId}`);
};