import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { useFormContext } from 'react-hook-form';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { PaymentMethod } from '../../types';
import { MembershipType } from '@/modules/membership/types';

export const createDuesSchema = z.object({
  dues: z.array(z.object({
    membership: z.object({
      id: z.string(),
      membershipType: z.nativeEnum(MembershipType),
    }),
    amountPaid: z.number(),
    paymentMethod: z.nativeEnum(PaymentMethod),
    year: z.coerce.number().gte(MFA_FOUNDING_YEAR),
    paymentDate: z.coerce.date()
      .max(new Date()),
  }))
    .min(1)
    .superRefine((items, ctx) => {
      const uniqueCount = new Set(items.map(i => `${i.membership.id},${i.year}`)).size;

      return items.length === uniqueCount;
    }),
});

export type CreateDuesSchema = z.infer<typeof createDuesSchema>;

export const createDuesSchemaResolver = zodResolver(createDuesSchema);

export const useCreateDuesFormContext = () => useFormContext<CreateDuesSchema>();