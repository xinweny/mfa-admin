import * as z from 'zod';

import { Province } from '../../types';

export const addressSchema = z.object({
  line1: z.string().min(1),
  line2: z.optional(z.string().min(1)),
  city: z.string().min(1),
  postalCode: z.string().min(1),
  province: z.nativeEnum(Province),
});

export type AddressSchema = z.infer<typeof addressSchema>;