'use client';

import { useState, useEffect } from 'react';
import useSWR from 'swr';
import { Check, ChevronsUpDown } from 'lucide-react';

import { cn } from '@/lib/cn';

import { ApiResponse } from '@/core/api/types';
import { GetMembershipsResponse, MembershipType } from '@/modules/membership/types';

import { useCreateDuesFormContext } from './schema';

import { serializeGetMembershipsUrlParams } from '@/modules/membership/state';

import { Button } from '@/components/ui/button';
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
} from '@/components/ui/command';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';

interface MembershipSearchInputProps {
  index: number;
  value: {
    id: string;
    membershipType: MembershipType;
  } | undefined;
  onSelect: (v: any) => void;
}

export function MembershipSearchInput({
  index,
  value,
  onSelect,
}: MembershipSearchInputProps) {
  const [open, setOpen] = useState<boolean>(false);
  const [query, setQuery] = useState<string>('');

  const { watch, setValue } = useCreateDuesFormContext();

  const year = watch(`dues.${index}.year`);

  useEffect(() => {
    setQuery('');
    setValue(`dues.${index}.membership`, undefined as any);
  }, [year]);

  const params = {
    query: query ? query : undefined,
    yearPaid: year,
    hasPaid: false,
    isActive: true,
    sinceTo: new Date(year, 1, 1),
  };

  const { data, isLoading } = useSWR(year
    ? `${process.env.NEXT_PUBLIC_MFA_API_URL}/memberships${serializeGetMembershipsUrlParams(params)}`
    : null,
    async (url: string) => {
      const res = await fetch(url, {
        headers: {
          'Content-Type': 'application/json',
        },
      });

      const data = await res.json();

      return data as ApiResponse<GetMembershipsResponse[]>;
    }
  );

  const memberships = data?.data || [];

  return (
    <Popover open={open} onOpenChange={setOpen}>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          role="combobox"
          aria-expanded={open}
          className="text-left w-full justify-between"
          disabled={!year}
        >
          <span className="w-auto overflow-hidden flex-auto text-ellipsis">
            {
            value
              ? memberships.find(m => m.id === value?.id)?.members.map(m => `${m.firstName} ${m.lastName}`).join(', ')
              : 'Select membership'
            }
          </span>
          <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-full p-0">
        <Command>
          <CommandInput
            value={query}
            onInput={e => {
              setQuery(e.currentTarget.value);
            }}
            placeholder="Search memberships"
          />
          <CommandList>
            <CommandEmpty>{isLoading ? 'Loading...' : 'No membership found.'}</CommandEmpty>
            <CommandGroup>
              {memberships.map(({ id, members, membershipType }) => (
                <CommandItem
                  key={id}
                  value={id}
                  onSelect={() => {
                    onSelect({ id, membershipType });
                    setOpen(false);
                  }}
                >
                  <Check
                    className={cn(
                      'mr-2 h-4 w-4',
                      value?.id === id ? 'opacity-100' : 'opacity-0'
                    )}
                  />
                  {members.map(m => `${m.firstName} ${m.lastName}`).join(', ')}
                </CommandItem>
              ))}
            </CommandGroup>
          </CommandList>
        </Command>
      </PopoverContent>
    </Popover>
  )
}
