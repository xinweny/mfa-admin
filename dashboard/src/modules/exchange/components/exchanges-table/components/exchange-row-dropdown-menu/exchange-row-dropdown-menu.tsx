import { RowDropdownMenu } from '@/core/data/components/row-dropdown-menu';
import { CopyIdDropdownMenuItem } from '@/core/data/components/copy-id-dropdown-menu-item';

interface ExchangeRowDropdownMenuProps {
 exchangeId: string;
}

export function ExchangeRowDropdownMenu({
  exchangeId,
}: ExchangeRowDropdownMenuProps) {
  return (
    <RowDropdownMenu>
      <CopyIdDropdownMenuItem
        id={exchangeId}
        label="Copy Exchange ID"
        message="Exchange ID copied."
      />
    </RowDropdownMenu>
  );
}