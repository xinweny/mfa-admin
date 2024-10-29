import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { PaymentMethod } from '../../types';

export const createDuesSchema = z.object({
  dues: z.array(z.object({
    membershipId: z.string(),
    amountPaid: z.literal(20).or(z.literal(30)),
    paymentMethod: z.nativeEnum(PaymentMethod),
    year: z.number().min(MFA_FOUNDING_YEAR),
    paymentDate: z.date()
      .max(new Date()),
  }))
    .min(1),
});

export type CreateDuesSchema = z.infer<typeof createDuesSchema>;

export const createDuesSchemaResolver = zodResolver(createDuesSchema);