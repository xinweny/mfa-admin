import { MembershipType, membershipTypeLabels } from '@/modules/membership/types';

import { Badge } from '@/components/ui/badge';

interface MembershipTypeBadgeProps {
  membershipType: MembershipType;
}

export function MembershipTypeBadge({
  membershipType,
}: MembershipTypeBadgeProps) {
  return (
    <Badge>
      {membershipTypeLabels[membershipType]}
    </Badge>
  );
}