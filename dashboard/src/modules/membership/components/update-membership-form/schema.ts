import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { membershipSchema } from '../membership-form-fields';

export const updateMembershipSchema = z.object({
  ...membershipSchema.shape,
  isActive: z.boolean(),
});

export type UpdateMembershipSchema = z.infer<typeof updateMembershipSchema>;

export const updateMembershipSchemaResolver = zodResolver(updateMembershipSchema);