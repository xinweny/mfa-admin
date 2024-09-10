import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { addressSchema } from '../address-form-fields';

export const upsertAddressSchema = addressSchema;

export type UpsertAddressSchema = z.infer<typeof upsertAddressSchema>;

export const upsertAddressSchemaResolver = zodResolver(upsertAddressSchema);