import { Label } from '@/components/ui/label';

interface DataTableFilterProps {
  name: string;
  label: string;
  children: React.ReactNode;
}

export function DataTableFilter({
  name,
  label,
  children,
}: DataTableFilterProps) {
  return (
    <div className="grid max-w-xs items-center gap-1.5">
      <Label
        htmlFor={name}
        className="font-semibold text-sm"
      >{label}</Label>
      {children}
    </div>
  );
}