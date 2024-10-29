import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';

interface MembershipTypeCellProps {
  id: string;
  membershipType: MembershipType
}

export function MembershipTypeCell({
  id,
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <Badge>
      {membershipTypeLabels[membershipType]}
    </Badge>
  );
}