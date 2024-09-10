import * as z from 'zod';

import { MembershipType } from '../../types';

export const membershipSchema = z.object({
  membershipType: z.nativeEnum(MembershipType),
  startDate: z.date(),
});

export type membershipSchema = z.infer<typeof membershipSchema>;