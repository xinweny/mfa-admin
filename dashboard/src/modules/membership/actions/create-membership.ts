'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { CreateMembershipRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const createMembership = async (req: CreateMembershipRequest) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships`,
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
  redirect(`/dashboard/memberships/${data.data.id}`);
};