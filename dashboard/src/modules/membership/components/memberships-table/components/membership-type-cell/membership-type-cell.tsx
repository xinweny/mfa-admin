import Link from 'next/link';

import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';

interface MembershipTypeCellProps {
  id: string;
  membershipType: MembershipType;
}

export function MembershipTypeCell({
  id,
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <Link href={`/dashboard/memberships/${id}`}>
      <Badge variant="outline">
        {membershipTypeLabels[membershipType]}
      </Badge>
    </Link>
  );
}