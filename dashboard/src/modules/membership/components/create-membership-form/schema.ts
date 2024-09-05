import * as z from 'zod';
import { isValidPhoneNumber } from 'libphonenumber-js';

import { MembershipType } from '../../types';

import { addressSchema } from '@/modules/address/schema';

export const createMembershipSchema = z.object({
  membershipType: z.nativeEnum(MembershipType),
  members: z.array(z.object({
    firstName: z.string().min(1),
    lastName: z.string().min(1),
    email: z.string().email(),
    phoneNumber: z.string().refine(isValidPhoneNumber),
    joinedDate: z.optional(z.date()),
  })),
  address: z.optional(addressSchema),
  startDate: z.date(),
});

export type CreateMembershipSchema = z.infer<typeof createMembershipSchema>;