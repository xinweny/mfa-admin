import { cn } from '@/lib/cn';

import { Badge } from '@/components/ui/badge';

interface BooleanBadgeProps {
  value: boolean;
  trueLabel: string;
  falseLabel: string;
}

export function BooleanBadge({
  value,
  trueLabel,
  falseLabel,
}: BooleanBadgeProps) {
  return (
    <Badge
      className={cn(
        'text-white',
        value
          ? 'bg-green-800 hover:bg-green-700'
          : 'bg-red-800 hover:bg-red-700'
      )}
    >
      {value ? trueLabel : falseLabel}
    </Badge>
  )
}