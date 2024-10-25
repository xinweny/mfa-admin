import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { mfaFoundingYear } from '@/core/constants';

export enum MembershipTypeInputValues {
  All = 'all',
  Single = 'single',
  Family = 'family',
  Honorary = 'honorary',
}

export enum HasPaidInputValues {
  All = 'null',
  Paid = 'true',
  NotPaid = 'false',
}

export const getMembershipsSchema = z.object({
  query: z.optional(z.string()),
  yearPaid: z
    .coerce.number().int()
    .gte(mfaFoundingYear),
  membershipType: z.nativeEnum(MembershipTypeInputValues),
  hasPaid: z.nativeEnum(HasPaidInputValues),
  startDateRange: z.object({
    from: z.optional(z.coerce.date()),
    to: z.optional(z.coerce.date()),
  }),
  isInactive: z.optional(z.boolean()),
});

export type GetMembershipsSchema = z.infer<typeof getMembershipsSchema>;

export const getMembershipsSchemaResolver = zodResolver(getMembershipsSchema);