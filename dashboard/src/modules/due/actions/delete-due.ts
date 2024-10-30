'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { ErrorResponse } from '@/core/api/types';

export const deleteDue = async (dueId: string) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/dues/${dueId}`,
    {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json; charset=UTF-8',
      },
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/dues');

  redirect('/dashboard/dues');
};