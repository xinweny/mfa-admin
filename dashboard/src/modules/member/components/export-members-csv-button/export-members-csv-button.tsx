import { format } from 'date-fns';

import { GetMembersResponse } from '../../types';

import { formatAddressString } from '@/modules/address/utils';

import { ExportCsvButton } from '@/core/data/components/export-csv-button';


interface ExportMembersCsvButtonProps {
  members: GetMembersResponse[];
}

export function ExportMembersCsvButton({
  members,
}: ExportMembersCsvButtonProps) {
  return (
    <ExportCsvButton
      csv={[
        ['First Name', 'Last Name', 'Email', 'Phone', 'Address', 'Joined', 'Active'],
        ...(members.map(({
          firstName,
          lastName,
          email,
          phoneNumber,
          membership: { address, isActive },
          joinedDate,
        }) => [
          firstName,
          lastName,
          email,
          phoneNumber || '',
          address ? formatAddressString(address) : '',
          joinedDate ? format(joinedDate, 'dd-LL-yyyy') : '',
          isActive ? 'yes' : 'no',
        ])),
      ]}
      fileName="members"
    />
  );
}