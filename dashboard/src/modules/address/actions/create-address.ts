'use server';

import { revalidatePath } from 'next/cache';

import { CreateAddressRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const createAddress = async (membershipId: string, req: CreateAddressRequest) => {
  const res = await fetch(
    `${process.env.MFA_API_URL}/memberships/${membershipId}/address`,
    {
      method: 'POST',
      body: JSON.stringify(req),
      headers: {
        'Content-Type': 'application/json; charset=UTF-8',
      },
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${membershipId}`);
};