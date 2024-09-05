import { Separator } from '@/components/ui/separator';

interface FormSectionHeaderProps {
  title: string;
}

export function FormSectionHeader({
  title,
}: FormSectionHeaderProps) {
  return (
    <div>
      <h3 className="text-xl font-semibold">{title}</h3>
      <Separator className="my-2" />
    </div>
  );
}