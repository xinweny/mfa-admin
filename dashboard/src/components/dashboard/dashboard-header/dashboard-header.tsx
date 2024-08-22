import Image from "next/image";
import Link from "next/link";

import mfaLogo from "@/assets/images/mfa-logo.png";

export function DashboardHeader() {
  return (
    <header className="p-4 flex items-center justify-between shadow-lg bg-">
      <Link href="/dashboard">
        <Image
          src={mfaLogo}
          className="rounded-full"
          height={48}
          width={48}
          alt="Mississauga Friendship Association"
        />
      </Link>
    </header>
  );
}