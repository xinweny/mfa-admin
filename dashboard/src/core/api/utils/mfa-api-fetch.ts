import { getAccessToken } from '@/modules/auth/actions';

interface MfaApiRequestInit extends RequestInit {
  body: any;
}

export const mfaApiFetch = async (path: string, req?: MfaApiRequestInit) => {
  const accessToken = await getAccessToken();

  const res = await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/${path}`,
    req
      ? {
      method: req.method,
      body: req.body ? JSON.stringify(req.body) : undefined,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`,
        ...req?.headers,
      },
    }
      : undefined
  );

  return res;
};