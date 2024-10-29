import {
  useQueryState,
  parseAsStringEnum,
} from 'nuqs';

export enum UpdateMembershipTabs {
  Membership = 'membership',
  Members = 'members',
  Address = 'address',
}

export const useUpdateMembershipTabsUrlParams = () => {
  return useQueryState(
    'tab',
    parseAsStringEnum<UpdateMembershipTabs>(Object.values(UpdateMembershipTabs)).withDefault(UpdateMembershipTabs.Membership),
  );
};