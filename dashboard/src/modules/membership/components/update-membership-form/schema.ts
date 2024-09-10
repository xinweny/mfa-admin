import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { MembershipType } from '../../types';

export const updateMembershipSchema = z.object({
  membershipType: z.nativeEnum(MembershipType),
  startDate: z.date(),
});

export type UpdateMembershipSchema = z.infer<typeof updateMembershipSchema>;

export const updateMembershipSchemaResolver = zodResolver(updateMembershipSchema);