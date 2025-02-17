import { cn } from '@/lib/cn';

import { BooleanBadge } from '@/components/ui/boolean-badge';

interface MississaugaResidentCellProps {
  city?: string;
}

export function MississaugaResidentCell({
  city,
}: MississaugaResidentCellProps) {
  if (city === undefined) return null;

  const isMississaugaResident = city.toLowerCase() === 'Mississauga'.toLowerCase();

  return (
    <BooleanBadge
      value={isMississaugaResident}
      trueLabel="Yes"
      falseLabel="No"
    />
  );
}