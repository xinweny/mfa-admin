'use server';

import { revalidatePath } from 'next/cache';

import { UpdateDueRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const updateDue = async (
  id: string,
  req: UpdateDueRequest
) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/dues/${id}`,
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

  revalidatePath('/dashboard/dues');
};