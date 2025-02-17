'use client';

import { format } from 'date-fns';

import { GetMembershipsResponse, membershipTypeLabels } from '../../types';

import { formatMemberNames } from '@/modules/member/utils';
import { formatAddressString } from '@/modules/address/utils';

import { useGetMembershipsUrlParams } from '../../state';

import { ExportCsvButton } from '@/core/data/components/export-csv-button';

interface ExportMembershipsCsvButtonProps {
  memberships: GetMembershipsResponse[];
}

export function ExportMembershipsCsvButton({
  memberships,
}: ExportMembershipsCsvButtonProps) {
  const [{ yearPaid }] = useGetMembershipsUrlParams();

  return (
    <ExportCsvButton
      csv={[
        ['Members', 'Type', 'Address', 'Since', `Paid ${yearPaid}`, 'Active'],
        ...(memberships.map(({
          members,
          membershipType,
          address,
          startDate,
          due,
          isActive,
        }) => [
          formatMemberNames(members),
          membershipTypeLabels[membershipType],
          address ? formatAddressString(address) : '',
          format(startDate, 'dd-LL-yyyy'),
          due ? 'yes' : 'no',
          isActive ? 'yes' : 'no',
        ])),
      ]}
      fileName="memberships"
    />
  );
}