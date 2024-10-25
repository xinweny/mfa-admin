import { GetMembersByDateResponse } from '../../types';

interface MemberCountTooltipProps {
  isActive?: boolean;
  payload?: {
    date: Date;
    count: number;
    members: GetMembersByDateResponse[];
  }[];
}

export function MemberCountTooltip({
  isActive = false,
  payload = [],
}: MemberCountTooltipProps) {
  if (!isActive || payload.length == 0) return null;

  return (
    <div>
    </div>
  );
}