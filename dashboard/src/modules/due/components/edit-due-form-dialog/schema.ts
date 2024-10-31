import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { PaymentMethod } from '../../types';

export const updateDueSchema = z.object({
  amountPaid: z.number(),
  paymentMethod: z.nativeEnum(PaymentMethod),
  year: z.coerce.number().gte(MFA_FOUNDING_YEAR),
  paymentDate: z.coerce.date()
    .max(new Date()),
});

export type UpdateDueSchema = z.infer<typeof updateDueSchema>;

export const updateDueSchemaResolver = zodResolver(updateDueSchema);