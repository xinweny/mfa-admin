import * as z from 'zod';

import { MembershipType } from '../../types';

export const updateMembershipSchema = z.object({
  membershipType: z.nativeEnum(MembershipType),
  startDate: z.date(),
});

export type UpdateMembershipSchema = z.infer<typeof updateMembershipSchema>;