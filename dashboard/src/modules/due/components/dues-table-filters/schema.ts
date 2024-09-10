import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { mfaFoundingYear } from '@/core/constants';

import { PaymentMethod } from '../../types';

export enum MembershipTypeInputValues {
  All = 'all',
  Single = 'single',
  Family = 'family',
}

export const getDuesSchema = z.object({
  year: z.optional(z
    .coerce.number().int()
    .gte(mfaFoundingYear)),
  membershipType: z.nativeEnum(MembershipTypeInputValues),
  paymentMethods: z.array(z.nativeEnum(PaymentMethod)),
  paymentDateRange: z.object({
    from: z.optional(z.coerce.date()),
    to: z.optional(z.coerce.date()),
  }),
});

export type GetDuesSchema = z.infer<typeof getDuesSchema>;

export const getDuesSchemaResolver = zodResolver(getDuesSchema);