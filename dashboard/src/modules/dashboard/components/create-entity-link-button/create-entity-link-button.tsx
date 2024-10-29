import Link from 'next/link';
import { PlusIcon } from 'lucide-react';

import { cn } from '@/lib/cn';

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
      className={cn(buttonVariants({ variant: 'default' }), 'gap-1')}
    >
      <PlusIcon width={16} />
      <span>{label}</span>
    </Link>
  );
}