import { useEffect } from 'react';
import { useFormContext } from 'react-hook-form';

import { CreateDuesSchema } from './schema';

import { MembershipType } from '@/modules/membership/types';

import { SINGLE_MEMBERSHIP_COST, FAMILY_MEMBERSHIP_COST } from '@/core/constants';

interface AmountPaidDisplayProps {
  index: number;
}

export function AmountPaidDisplay({
  index,
}: AmountPaidDisplayProps) {
  const { watch, setValue } = useFormContext<CreateDuesSchema>();

  const membershipType = watch(`dues.${index}.membership.membershipType`);

  console.log(watch());

  useEffect(() => {
    if (membershipType === undefined) return;

    setValue(`dues.${index}.amountPaid`, getAmountPaid(membershipType));
  }, [membershipType]);

  const amountPaid = watch(`dues.${index}.amountPaid`) || 0;

  return (
    <span className="font-semibold">{`$${amountPaid}.00`}</span>
  );
}

const getAmountPaid = (membershipType: MembershipType) => {
  switch (membershipType) {
    case MembershipType.Single:
      return SINGLE_MEMBERSHIP_COST;
    case MembershipType.Family:
      return FAMILY_MEMBERSHIP_COST;
    default:
      return 0;
  }
};