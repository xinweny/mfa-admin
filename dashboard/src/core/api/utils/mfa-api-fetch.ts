interface MfaApiFetchOptions {
  client: boolean;
}

interface MfaApiRequestInit extends RequestInit {
  body: any;
}

export const mfaApiFetch = async (path: string, req?: MfaApiRequestInit, options: MfaApiFetchOptions = {
  client: true
}) => {
  const accessToken = '';

  return await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/${path}`,
    req
      ? {
      method: req.method,
      body: JSON.stringify(req.body),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${accessToken}`,
        ...req.headers,
      },
    }
      : undefined
  );
};