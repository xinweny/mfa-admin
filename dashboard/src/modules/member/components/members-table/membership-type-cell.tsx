import { MembershipType } from '@/modules/membership/types';

import { MembershipTypeBadge } from '@/modules/membership/components/membership-type-badge';

interface MembershipTypeCellProps {
  id: string;
  membershipType: MembershipType
}

export function MembershipTypeCell({
  id,
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <MembershipTypeBadge membershipType={membershipType} />
  );
}