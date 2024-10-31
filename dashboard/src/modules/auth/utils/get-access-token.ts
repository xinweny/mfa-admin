import { getSession } from '@auth0/nextjs-auth0';

export const getAccessToken = async () => {
  const session = await getSession();

  if (!session?.user) return undefined;

  const params = new URLSearchParams({
    client_id: process.env.AUTH0_CLIENT_ID as string,
    client_secret: process.env.AUTH0_CLIENT_SECRET as string,
    audience: process.env.AUTH0_AUDIENCE as string,
    grant_type: 'client_credentials',
  });

  const res = await fetch(
    `${process.env.AUTH0_ISSUER_BASE_URL}/oauth/token?${params.toString()}`,
  );

  const token: string = await res.json();

  return token;
}