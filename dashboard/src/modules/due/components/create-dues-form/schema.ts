import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { PaymentMethod } from '../../types';

export const createDuesSchema = z.object({
  dues: z.array(z.object({
    membershipId: z.string(),
    amountPaid: z.number(),
    paymentMethod: z.nativeEnum(PaymentMethod),
    year: z.number().min(MFA_FOUNDING_YEAR),
    paymentDate: z.date()
      .max(new Date()),
  }))
    .min(1)
    .superRefine((items, ctx) => {
      const uniqueCount = new Set(items.map(i => `${i.membershipId},${i.year}`)).size;

      return items.length === uniqueCount;
    }),
});

export type CreateDuesSchema = z.infer<typeof createDuesSchema>;

export const createDuesSchemaResolver = zodResolver(createDuesSchema);