import { cn } from '@/lib/cn';

import { Badge } from '@/components/ui/badge';

interface MississaugaResidentCellProps {
  city?: string;
}

export function MississaugaResidentCell({
  city,
}: MississaugaResidentCellProps) {
  if (city === undefined) return null;

  const isMississaugaResident = city.toLowerCase() === 'Mississauga'.toLowerCase();

  return (
    <Badge
      variant="outline"
      className={cn(
        'text-white',
        isMississaugaResident
          ? 'bg-green-800 hover:bg-green-700'
          : 'bg-red-800 hover:bg-red-700'
      )}
    >
      {isMississaugaResident ? 'Yes' : 'No'}
    </Badge>
  );
}