'use server';

import { revalidatePath } from 'next/cache';

import { UpdateMembershipRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const updateMembership = async (id: string, req: UpdateMembershipRequest) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships/${id}`,
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
  revalidatePath(`/dashboard/memberships/${id}`);
};