'use client';

import { useState, useEffect } from 'react';

import { CommandIcon } from 'lucide-react';

import {
  CommandDialog,
  CommandInput,
  CommandList,
  CommandEmpty,
} from '@/components/ui/command';
import { Button } from '@/components/ui/button';

export function DashboardCommand() {
  const [open, setOpen] = useState(false)
 
  useEffect(() => {
    const down = (e: KeyboardEvent) => {
      if (e.key === 'k' && (e.metaKey || e.ctrlKey)) {
        e.preventDefault();
        setOpen((open) => !open);
      }
    }

    document.addEventListener('keydown', down);

    return () => document.removeEventListener('keydown', down);
  }, [])

  return (
    <>
      <Button
        className="border gap-2 rounded-full"
        onClick={() => { setOpen(true); }}
        variant="secondary"
      >
        <CommandIcon size={16} />
        <span>Search commands</span>
      </Button>
      <CommandDialog open={open} onOpenChange={setOpen}>
        <CommandInput
          placeholder="Type a command or search"
        />
        <CommandList>
          <CommandEmpty>No results found.</CommandEmpty>
        </CommandList>
      </CommandDialog>
    </>
  );
}