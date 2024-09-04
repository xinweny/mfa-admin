import Link from 'next/link';
import { PlusIcon } from 'lucide-react';

import { buttonVariants } from '@/components/ui/button';

interface CreateEntityLinkButtonProps {
  path: string;
  label: string;
}

export function CreateEntityLinkButton({
  path,
  label,
}: CreateEntityLinkButtonProps) {
  return (
    <Link
      href={`/dashboard/${path}`}
      className={buttonVariants({ variant: 'default' })}
    >
      <PlusIcon />
      <span>{label}</span>
    </Link>
  );
}