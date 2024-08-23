import Image from 'next/image';
import Link from 'next/link';

import mfaLogo from '@/assets/images/mfa-logo.png';

export function DashboardHeader() {
  return (
    <header>
      <Link href="/dashboard">
        <Image
          src={mfaLogo}
          height={48}
          width={48}
          alt="Mississauga Friendship Association"
        />
      </Link>
    </header>
  );
}