'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { CreateDuesRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const createDues = async (req: CreateDuesRequest) => {
  const res = await mfaApiFetch(
    'dues',
    {
      method: 'POST',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/memberships');
  revalidatePath('/dashboard/dues');

  redirect(`/dashboard/dues`);
};