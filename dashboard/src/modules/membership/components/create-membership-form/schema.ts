import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';

import { membershipSchema } from '../membership-form-fields';
import { addressSchema } from '@/modules/address/components/address-form-fields';
import { memberSchema } from '@/modules/member/components/member-form-fields';
import { useFormContext } from 'react-hook-form';

export const createMembershipSchema = z.object({
  ...(membershipSchema.shape),
  members: z.array(memberSchema),
  address: z.array(addressSchema).max(1),
});

export type CreateMembershipSchema = z.infer<typeof createMembershipSchema>;

export const createMembershipSchemaResolver = zodResolver(createMembershipSchema);

export const useCreateMembershipFormContext = () => useFormContext<CreateMembershipSchema>();