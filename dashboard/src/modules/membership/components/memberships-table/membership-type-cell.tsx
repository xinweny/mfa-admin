import { MembershipType } from '@/modules/membership/types';

import { MembershipTypeBadge } from '../membership-type-badge';

interface MembershipTypeCellProps {
  id: string;
  membershipType: MembershipType;
}

export function MembershipTypeCell({
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <MembershipTypeBadge membershipType={membershipType} />
  );
}