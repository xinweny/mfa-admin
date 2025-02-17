import { format } from 'date-fns';

import { GetMembershipsResponse, membershipTypeLabels } from '../../types';
import { provinceLabels } from '@/modules/address/types';

import { formatMemberNames } from '@/modules/member/utils';

import { ExportCsvButton } from '@/core/data/components/export-csv-button';

interface ExportMembershipsCsvButtonProps {
  memberships: GetMembershipsResponse[];
}

export function ExportMembershipsCsvButton({
  memberships,
}: ExportMembershipsCsvButtonProps) {
  return (
    <ExportCsvButton
      csv={[
        ['Members', 'Type', 'Address', 'Since'],
        ...(memberships.map(({
          members,
          membershipType,
          address,
          startDate,
        }) => [
          formatMemberNames(members),
          membershipTypeLabels[membershipType],
          address
            ? `${address.line1}, ${address.line2 ? `${address.line2}, ` : ''}, ${address.city}, ${provinceLabels[address.province]} ${address.postalCode}`
            : '',
          format(startDate, 'dd-LL-yyyy'),
        ]))
      ]}
      fileName="memberships"
    />
  );
}