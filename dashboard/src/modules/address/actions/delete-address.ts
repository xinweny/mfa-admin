'use server';

import { revalidatePath } from 'next/cache';

import { ErrorResponse } from '@/core/api/types';

export const deleteAddress = async (membershipId: string) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships/${membershipId}/address`,
    {
      method: 'DELETE',
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath(`/dashboard/memberships/${membershipId}`);
};