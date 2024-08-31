import * as z from 'zod';

import { mfaFoundingYear } from '@/constants';

export const getMembershipsSchema = z.object({
  query: z.string(),
  yearPaid: z
    .coerce.number().int()
    .gte(mfaFoundingYear),
});

export type GetMembershipsSchema = z.infer<typeof getMembershipsSchema>;