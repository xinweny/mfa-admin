import { getSession } from '@auth0/nextjs-auth0';
import { redirect } from 'next/navigation';

export default async function IndexPage() {
  const session = await getSession();

  if (session?.user) redirect('/dashboard');

  redirect('/api/auth/login');
}
