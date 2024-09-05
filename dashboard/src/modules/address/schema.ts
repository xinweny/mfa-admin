import * as z from 'zod';

import { Province } from './types';

export const addressSchema = z.object({
  line1: z.string(),
  line2: z.optional(z.string()),
  city: z.string(),
  postalCode: z.string(),
  province: z.nativeEnum(Province),
});

export type AddressSchema = z.infer<typeof addressSchema>;