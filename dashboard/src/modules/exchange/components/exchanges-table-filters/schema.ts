import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

export enum ExchangeTypeInputValues {
  All = 'all',
  Host = 'host',
  Delegate = 'delegate',
}

export const getExchangesSchema = z.object({
  query: z.optional(z.string()),
  year: z.optional(z
    .coerce.number().int()
    .gte(MFA_FOUNDING_YEAR)),
  exchangeType: z.nativeEnum(ExchangeTypeInputValues),
});

export type GetExchangesSchema = z.infer<typeof getExchangesSchema>;

export const getExchangesSchemaResolver = zodResolver(getExchangesSchema);