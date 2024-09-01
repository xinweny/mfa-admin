import * as z from 'zod';

import { mfaFoundingYear } from '@/constants';

export enum MembershipTypeValues {
  All = 'all',
  Single = 'single',
  Family = 'family',
  Honorary = 'honorary',
}

export const getMembershipsSchema = z.object({
  query: z.optional(z.string()),
  yearPaid: z
    .coerce.number().int()
    .gte(mfaFoundingYear),
  membershipType: z.nativeEnum(MembershipTypeValues),
});

export type GetMembershipsSchema = z.infer<typeof getMembershipsSchema>;