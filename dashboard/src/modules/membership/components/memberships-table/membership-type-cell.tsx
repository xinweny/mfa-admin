import Link from 'next/link';

import { MembershipType } from '@/modules/membership/types';

import { MembershipTypeBadge } from '../membership-type-badge';

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
      <MembershipTypeBadge membershipType={membershipType} />
    </Link>
  );
}