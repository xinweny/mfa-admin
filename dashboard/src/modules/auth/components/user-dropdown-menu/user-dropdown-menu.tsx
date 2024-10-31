'use client';

import { useUser } from '@auth0/nextjs-auth0/client';

import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from '@/components/ui/dropdown-menu';
import { Avatar, AvatarImage } from '@/components/ui/avatar';


export function UserDropdownMenu() {
  const { user } = useUser();

  if (!user) return null;

  return (
    <DropdownMenu>
      <DropdownMenuTrigger>
        <Avatar>
          <AvatarImage src={user.picture || undefined} />
        </Avatar>
      </DropdownMenuTrigger>
      <DropdownMenuContent>
        <a
          href="/api/auth/logout"
          className="hover:cursor-pointer"
        >
          <DropdownMenuItem>
            Logout
          </DropdownMenuItem>
        </a>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}