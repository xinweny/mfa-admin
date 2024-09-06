'use server';

import { revalidatePath } from 'next/cache';

import { CreateMembershipRequest } from '../types';

export const createMembership = async (data: CreateMembershipRequest) => {
  console.log(data);

  const res = await fetch(
    `${process.env.MFA_API_URL}/memberships`,
    {
      method: 'POST',
      body: JSON.stringify(data),
      headers: {
        'Content-Type': 'application/json; charset=UTF-8',
      },
    }
  ).then(res => res.json());

  console.log(res);

  revalidatePath('/memberships');

  return res;
};