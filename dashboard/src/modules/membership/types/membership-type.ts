export enum MembershipType {
  Single = '1',
  Family = '2',
  Honorary = '3',
}

export const membershipTypeLabels: Record<MembershipType, string> = {
  [MembershipType.Single]: 'Single',
  [MembershipType.Family]: 'Family',
  [MembershipType.Honorary]: 'Honorary',
};