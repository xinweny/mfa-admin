import * as z from 'zod';

import { mfaFoundingYear } from '@/core/constants';

export enum ExchangeTypeInputValues {
  All = 'all',
  Host = 'host',
  Delegate = 'delegate',
}

export const getExchangesSchema = z.object({
  query: z.optional(z.string()),
  fromYear: z.optional(z
    .coerce.number().int()
    .gte(mfaFoundingYear)),
  toYear: z.optional(z
    .coerce.number().int()
    .lte(new Date().getFullYear())),
  exchangeType: z.nativeEnum(ExchangeTypeInputValues),
});

export type GetExchangesSchema = z.infer<typeof getExchangesSchema>;