import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

export enum MembershipTypeInputValues {
  All = 'all',
  Single = 'single',
  Family = 'family',
  Honorary = 'honorary',
}

export enum HasPaidInputValues {
  All = 'all',
  Paid = 'paid',
  NotPaid = 'not_paid',
}

export enum IsActiveInputValues {
  All = 'all',
  Active = 'active',
  Inactive = 'inactive'
}

export const getMembershipsSchema = z.object({
  query: z.optional(z.string()),
  yearPaid: z
    .coerce.number().int()
    .gte(MFA_FOUNDING_YEAR),
  membershipType: z.nativeEnum(MembershipTypeInputValues),
  hasPaid: z.nativeEnum(HasPaidInputValues),
  startDateRange: z.object({
    from: z.optional(z.coerce.date()),
    to: z.optional(z.coerce.date()),
  }),
  isActive: z.nativeEnum(IsActiveInputValues),
});

export type GetMembershipsSchema = z.infer<typeof getMembershipsSchema>;

export const getMembershipsSchemaResolver = zodResolver(getMembershipsSchema);