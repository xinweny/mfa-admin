'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { UpdateMembershipRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const updateMembership = async (id: string, req: UpdateMembershipRequest) => {
  try {
    const res = await fetch(
      `${process.env.MFA_API_URL}/memberships/${id}`,
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
    redirect(`/dashboard/memberships/${data.data.id}`);
  } catch {
    return { error: 'Unable to create membership.' };
  }
};