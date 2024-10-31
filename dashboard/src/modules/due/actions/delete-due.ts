'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const deleteDue = async (dueId: string) => {
  const res = await mfaApiFetch(
    `dues/${dueId}`,
    {
      method: 'DELETE',
      body: undefined,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/dues');

  redirect('/dashboard/dues');
};