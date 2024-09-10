import * as z from 'zod';

import { membershipSchema } from '../membership-form-fields';
import { addressSchema } from '@/modules/address/components/address-form-fields';
import { memberSchema } from '@/modules/member/components/member-form-fields';

export const createMembershipSchema = z.object({
  ...(membershipSchema.shape),
  members: z.array(memberSchema),
  address: z.array(addressSchema).max(1),
});

export type CreateMembershipSchema = z.infer<typeof createMembershipSchema>;