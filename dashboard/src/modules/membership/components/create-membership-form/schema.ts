import * as z from 'zod';

import { MembershipType } from '../../types';

import { addressSchema } from '@/modules/address/schema';
import { memberSchema } from '@/modules/member/schema';

export const createMembershipSchema = z.object({
  membershipType: z.nativeEnum(MembershipType),
  members: z.array(memberSchema),
  address: z.array(addressSchema).max(1),
  startDate: z.date(),
});

export type CreateMembershipSchema = z.infer<typeof createMembershipSchema>;