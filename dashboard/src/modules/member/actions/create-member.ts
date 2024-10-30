'use server';

import { revalidatePath } from 'next/cache';

import { ErrorResponse } from '@/core/api/types';
import { CreateMemberRequest } from '../types';

export const createMember = async (
  req: CreateMemberRequest
) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/members`,
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
  revalidatePath('/dashboard/members');
};