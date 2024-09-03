import Link from 'next/link';

import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';
import {
  TooltipProvider,
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from '@/components/ui/tooltip';

interface MembershipCellProps {
  id: string;
  membershipType: MembershipType;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
}

export function MembershipCell({
  id,
  membershipType,
  members,
}: MembershipCellProps) {
  return (
    <TooltipProvider>
      <Tooltip>
        <TooltipTrigger asChild>
          <Link href={`/dashboard/memberships/${id}`}>
            <Badge variant="outline">
              {membershipTypeLabels[membershipType]}
            </Badge>
          </Link>
        </TooltipTrigger>
        <TooltipContent>
          <ul>
            {members.map(m => (
              <li key={m.id}>{`${m.firstName} ${m.lastName.toUpperCase()}`}</li>
            ))}
          </ul>
        </TooltipContent>
      </Tooltip>
    </TooltipProvider>
  );
}