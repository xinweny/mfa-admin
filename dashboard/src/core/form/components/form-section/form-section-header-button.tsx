import { ButtonHTMLAttributes } from 'react';

import { LucideIcon, PlusIcon } from 'lucide-react';

import { Button } from '@/components/ui/button';


interface FormSectionHeaderButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  label: string;
  icon?: LucideIcon
}

export function FormSectionHeaderButton({
  icon = PlusIcon,
  label,
  ...props
}: FormSectionHeaderButtonProps) {
  const Icon = icon;

  return (
    <Button
      type="button"
      variant="link"
      className="gap-2"
      {...props}
    >
      <Icon width={16} />
      <span>{label}</span>
    </Button>
  );
}