import Image from "next/image";
import Link from "next/link";

import { AppBar } from "@mui/material";

import mfaLogo from "@/assets/images/mfa-logo.png";

export function DashboardHeader() {
  return (
    <AppBar>
      <Link href="/dashboard">
        <Image
          src={mfaLogo}
          height={48}
          width={48}
          alt="Mississauga Friendship Association"
        />
      </Link>
    </AppBar>
  );
}