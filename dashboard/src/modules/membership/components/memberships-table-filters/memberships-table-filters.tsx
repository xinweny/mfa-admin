'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import { MembershipType } from '../../types';

import {
  getMembershipsSchema,
  GetMembershipsSchema,
  MembershipTypeValues,
} from './schema';

import { mfaFoundingYear } from '@/constants';

import { useGetMembershipsUrlParams } from '../../state';

import { DataTableFiltersForm } from '@/modules/data/components/data-table-filters-form';
import { Input } from '@/components/ui/input';
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from '@/components/ui/popover';
import { Button } from '@/components/ui/button';
import { RadioGroup, RadioGroupItem } from '@/components/ui/radio-group';
import { Label } from '@/components/ui/label';

export function MembershipsTableFilters() {
  const [params, setParams] = useGetMembershipsUrlParams();

  const form = useForm<GetMembershipsSchema>({
    defaultValues: {
      query: params.query || '',
      yearPaid: params.yearPaid,
      membershipType: (Object.keys(membershipTypeValues) as MembershipTypeValues[])
        .find(k => membershipTypeValues[k].type === params.membershipType) || MembershipTypeValues.All,
    },
    resolver: zodResolver(getMembershipsSchema),
  });

  const handleSubmit = async (data: GetMembershipsSchema) => {
    await setParams({
      query: data.query || null,
      yearPaid: data.yearPaid,
      membershipType: membershipTypeValues[data.membershipType].type,
    });
  };

  return (
    <DataTableFiltersForm
      form={form}
      onSubmit={handleSubmit}
      filters={[
        {
          label: 'Search',
          name: 'query',
          render: ({ field }) => (
            <Input
              placeholder="Search names"
              {...field}
            />
          ),
        },
        {
          label: 'Year Paid',
          name: 'yearPaid',
          render: ({ field }) => (
            <Input
              type="number"
              min={mfaFoundingYear}
              {...field}
            />
          ),
        },
        {
          label: 'Membership Types',
          name: 'membershipType',
          render: ({ field }) => (
            <Popover>
              <PopoverTrigger asChild>
                <Button variant="outline" className="justify-start">
                  {membershipTypeValues[field.value as MembershipTypeValues].label}
                </Button>
              </PopoverTrigger>
              <PopoverContent>
                <RadioGroup
                  onValueChange={field.onChange}
                  defaultValue={field.value as MembershipTypeValues}
                >
                  {Object.entries(membershipTypeValues).map(([key, value]) => (
                    <div key={key} className="flex items-center gap-2">
                      <RadioGroupItem value={key} />
                      <Label>{value.label}</Label>
                    </div>
                  ))}
                </RadioGroup>
              </PopoverContent>
            </Popover>
          ),
        }
      ]}
      reset={{
        query: '',
        yearPaid: new Date().getFullYear(),
        membershipType: MembershipTypeValues.All,
      }}
    />
  );
}

const membershipTypeValues = {
  [MembershipTypeValues.All]: {
    type: null,
    label: 'All',
  },
  [MembershipTypeValues.Single]: {
    type: MembershipType.Single,
    label: 'Single',
  },
  [MembershipTypeValues.Family]: {
    type: MembershipType.Family,
    label: 'Family',
  },
  [MembershipTypeValues.Honorary]: {
    type: MembershipType.Honorary,
    label: 'Honorary',
  },
} satisfies {
  [key in MembershipTypeValues]: {
    type: MembershipType | null,
    label: string,
  }
};

