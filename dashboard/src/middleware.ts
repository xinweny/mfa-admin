import { NextRequest, NextResponse } from 'next/server';
import { getAccessToken } from '@auth0/nextjs-auth0/edge';

export async function middleware(req: NextRequest) {
  const { accessToken } = await getAccessToken();

  const requestHeaders = new Headers(req.headers);

  requestHeaders.set('Authorization', `Bearer ${accessToken}`);

  return NextResponse.next({
    request: {
      headers: requestHeaders,
    },
  });
}