import { getAccessToken } from '@/modules/auth/utils';

interface MfaApiRequestInit extends RequestInit {
  body: any;
}

export const mfaApiFetch = async (path: string, req?: MfaApiRequestInit) => {
  const accessToken = await getAccessToken();

  return await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/${path}`,
    req
      ? {
      method: req.method,
      body: req.body ? JSON.stringify(req.body) : undefined,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`,
        ...req.headers,
      },
    }
      : undefined
  );
};