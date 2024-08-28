import { MembershipType } from '../types';

export const membershipTypeLabels: Record<MembershipType, string> = {
  [MembershipType.Single]: 'Single',
  [MembershipType.Family]: 'Family',
  [MembershipType.Honorary]: 'Honorary',
};