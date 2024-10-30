'use server';

import { revalidatePath } from 'next/cache';

import { ErrorResponse } from '@/core/api/types';

export const deleteMember = async (memberId: string) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/members/${memberId}`,
    {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json; charset=UTF-8',
      },
    }
  );
  
  const data = await res.json();

  console.log(data);

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/members');
};