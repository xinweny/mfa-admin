import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { IsActiveInputValues } from '@/modules/membership/components/memberships-table-filters/schema';

export enum IsMississaugaResidentInputValues {
  All = 'null',
  Yes = 'true',
  No = 'false',
}

export const getMembersSchema = z.object({
  query: z.optional(z.string()),
  isMississaugaResident: z.nativeEnum(IsMississaugaResidentInputValues),
  joinedDateRange: z.object({
    from: z.optional(z.coerce.date()),
    to: z.optional(z.coerce.date()),
  }),
  isActive: z.nativeEnum(IsActiveInputValues),
});

export type GetMembersSchema = z.infer<typeof getMembersSchema>;

export const getMembersSchemaResolver = zodResolver(getMembersSchema);