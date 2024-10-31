'use server';

import { revalidatePath } from 'next/cache';

import { UpdateDueRequest } from '../types';
import { ErrorResponse } from '@/core/api/types';

import { mfaApiFetch } from '@/core/api/utils';

export const updateDue = async (
  id: string,
  req: UpdateDueRequest
) => {
  const res = await mfaApiFetch(
    `dues/${id}`,
    {
      method: 'PUT',
      body: req,
    }
  );
  
  const data = await res.json();

  if (!res.ok) throw new ErrorResponse(data);

  revalidatePath('/dashboard/dues');
};