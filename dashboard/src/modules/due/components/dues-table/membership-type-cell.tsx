import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';

interface MembershipTypeCellProps {
  membershipType: MembershipType;
}

export function MembershipTypeCell({
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <Badge>
      {membershipTypeLabels[membershipType]}
    </Badge>
  );
}