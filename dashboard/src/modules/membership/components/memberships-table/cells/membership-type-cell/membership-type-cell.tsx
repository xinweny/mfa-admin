import { MembershipType } from '@/modules/membership/types';

import { membershipTypeLabels } from '@/modules/membership/constants';

import { Badge } from '@/components/ui/badge';

interface MembershipTypeCellProps {
  membershipType: MembershipType
}

export function MembershipTypeCell({
  membershipType,
}: MembershipTypeCellProps) {
  return (
    <Badge variant="outline">
      {membershipTypeLabels[membershipType]}
    </Badge>
  );
}