import Link from 'next/link';

import { Badge } from '@/components/ui/badge';

interface ActivityCellProps {
  id: string;
  isActive: boolean;
}

export function ActivityCell({
  id,
  isActive,
}: ActivityCellProps) {
  return (
    <Link href={`/dashboard/memberships/${id}`}>
      <Badge>
        {isActive}
      </Badge>
    </Link>
  );
}