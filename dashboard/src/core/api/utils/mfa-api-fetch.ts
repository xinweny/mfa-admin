interface MfaApiRequestInit extends RequestInit {
  body: any;
}

export const mfaApiFetch = async (path: string, req?: MfaApiRequestInit) => {
  return await fetch(
    `${process.env.NEXT_PUBLIC_MFA_API_URL}/${path}`,
    req
      ? {
      method: req.method,
      body: JSON.stringify(req.body),
      headers: {
        'Content-Type': 'application/json',
        ...req.headers,
      },
    }
      : undefined
  );
};