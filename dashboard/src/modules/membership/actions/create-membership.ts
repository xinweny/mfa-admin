'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';

import { CreateMembershipRequest } from '../types';

export const createMembership = async (req: CreateMembershipRequest) => {
  try {
    const res = await fetch(
      `${process.env.MFA_API_URL}/memberships`,
      {
        method: 'POST',
        body: JSON.stringify(req),
        headers: {
          'Content-Type': 'application/json; charset=UTF-8',
        },
      }
    );

    if (!res.ok) throw new Error();
    
    const data = await res.json();
  
    revalidatePath('/dashboard/memberships');
    redirect(`/dashboard/memberships/${data.data.id}`);
  } catch {
    return { error: 'Unable to create membership.' };
  }
};