import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { mfaFoundingYear } from '@/core/constants';

export enum ExchangeTypeInputValues {
  All = 'all',
  Host = 'host',
  Delegate = 'delegate',
}

export const getExchangesSchema = z.object({
  query: z.optional(z.string()),
  year: z.optional(z
    .coerce.number().int()
    .gte(mfaFoundingYear)),
  exchangeType: z.nativeEnum(ExchangeTypeInputValues),
});

export type GetExchangesSchema = z.infer<typeof getExchangesSchema>;

export const getExchangesSchemaResolver = zodResolver(getExchangesSchema);