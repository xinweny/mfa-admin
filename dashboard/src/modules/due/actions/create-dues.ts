'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { CreateDuesRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

export const createDues = async (req: CreateDuesRequest) => {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/dues`,
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
  revalidatePath('/dashboard/dues');

  redirect(`/dashboard/dues`);
};