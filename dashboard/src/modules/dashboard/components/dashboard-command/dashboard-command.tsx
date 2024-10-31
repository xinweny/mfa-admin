'use client';

import { useState, useEffect } from 'react';
import { UserPlusIcon, CircleDollarSignIcon } from 'lucide-react';
import { useRouter } from 'next/navigation';

import {
  CommandDialog,
  CommandInput,
  CommandList,
  CommandEmpty,
  CommandGroup,
} from '@/components/ui/command';
import { Button } from '@/components/ui/button';
import { Badge } from '@/components/ui/badge';
import { DialogTitle } from '@/components/ui/dialog';

import { DashboardCommandItem } from './dashboard-command-item';

export function DashboardCommand() {
  const router = useRouter();

  const [open, setOpen] = useState(false);
 
  useEffect(() => {
    const down = (e: KeyboardEvent) => {
      if (e.key === 'k' && (e.metaKey || e.ctrlKey)) {
        e.preventDefault();
        setOpen((open) => !open);
      }
    };

    document.addEventListener('keydown', down);

    return () => document.removeEventListener('keydown', down);
  }, []);

  return (
    <>
      <Button
        className="border gap-2 rounded-lg justify-between items-center"
        onClick={() => { setOpen(true); }}
        variant="outline"
      >
        <span>Search commands</span>
        <Badge
          className="px-1.5 rounded-lg"
          variant="outline"
        >
          <span>⌘K</span>
        </Badge>
      </Button>
      <CommandDialog open={open} onOpenChange={setOpen}>
        <DialogTitle className="Command" hidden />
        <CommandInput
          placeholder="Type a command or search"
        />
        <CommandList>
          <CommandEmpty>No results found.</CommandEmpty>
          <CommandGroup heading="Suggestions">
            <DashboardCommandItem
              icon={UserPlusIcon}
              label="New Membership"
              onSelect={() => {
                router.push('/dashboard/memberships/new');
              }}
              setOpen={setOpen}
            />
            <DashboardCommandItem
              icon={CircleDollarSignIcon}
              label="Create Due Receipts"
              onSelect={() => {
                router.push('/dashboard/dues/new');
              }}
              setOpen={setOpen}
            />
          </CommandGroup>
        </CommandList>
      </CommandDialog>
    </>
  );
}