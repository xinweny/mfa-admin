import Link from 'next/link';

import { membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';
import {
  TooltipProvider,
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from '@/components/ui/tooltip';

interface MembersCellProps {
  id: string;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
}

export function MembersCell({
  id,
  members,
}: MembersCellProps) {
  return (
    <ul>
      {members.map(m => (
        <li key={m.id}>{`${m.firstName} ${m.lastName.toUpperCase()}`}</li>
      ))}
    </ul>
  );
}