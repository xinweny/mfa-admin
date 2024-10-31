'use server';

import { getSession } from '@auth0/nextjs-auth0';

import { GetAccessTokenResponse } from '../types';

export const getAccessToken = async () => {
  const session = await getSession();

  if (!session?.user) return undefined;

  const res = await fetch(
    `${process.env.AUTH0_ISSUER_BASE_URL}/oauth/token`,
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        client_id: process.env.AUTH0_CLIENT_ID as string,
        client_secret: process.env.AUTH0_CLIENT_SECRET as string,
        audience: process.env.AUTH0_AUDIENCE as string,
        grant_type: 'client_credentials',
      }),
    }
  );

  const data: GetAccessTokenResponse = await res.json();

  return data.access_token;
}