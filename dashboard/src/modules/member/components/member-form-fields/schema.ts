import * as z from 'zod';
import { parse, isPossibleNumber } from 'libphonenumber-js';
import { zodResolver } from '@hookform/resolvers/zod';

export const memberSchema = z.object({
  firstName: z.string().min(1),
  lastName: z.string().min(1),
  email: z.string().email().min(1),
  phoneNumber: z.string()
    .refine(v => {
      const number = parse(v, { defaultCountry: 'CA' });
      return isPossibleNumber(number);
    }, 'Please enter a valid Canadian number.'),
  joinedDate: z.date(),
});

export type MemberSchema = z.infer<typeof memberSchema>;

export const memberSchemaResolver = zodResolver(memberSchema);