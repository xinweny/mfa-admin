'use client';

import Link from 'next/link';
import { MoveLeftIcon } from 'lucide-react';

import { cn } from '@/lib/cn';

import { buttonVariants } from '@/components/ui/button';

interface BackButtonProps {
  href: string;
}

export function BackButton({
  href,
}: BackButtonProps) {
  return (
    <Link
      href={href}
      className={cn(buttonVariants({ variant: 'link' }), 'gap-2')}
    >
      <MoveLeftIcon width={16} />
      <span>Back</span>
    </Link>
  );
}