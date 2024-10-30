'use server';

import { revalidatePath } from 'next/cache';

import { UpdateAddressRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const updateAddress = async (membershipId: string, req: UpdateAddressRequest) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships/${membershipId}/address`,
    {
      method: 'PUT',
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