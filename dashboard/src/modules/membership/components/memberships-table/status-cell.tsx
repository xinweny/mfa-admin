import { BooleanBadge } from '@/core/ui/components/boolean-badge';

interface StatusCellProps {
  isActive: boolean;
}

export function StatusCell({
  isActive,
}: StatusCellProps) {
  return (
    <BooleanBadge
      value={isActive}
      trueLabel="Active"
      falseLabel="Inactive"
    />
  );
}