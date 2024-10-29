import { MoreHorizontal } from 'lucide-react';

import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
} from '@/components/ui/dropdown-menu';
import { Button } from '@/components/ui/button';
import { Dialog } from '@/components/ui/dialog';

interface RowDropdownMenuProps {
  children: React.ReactNode;
  dialog?: React.ReactNode;
}

export function RowDropdownMenu({
  children,
  dialog,
}: RowDropdownMenuProps) {
  return (
    <Dialog>
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant="ghost" className="h-8 w-8 p-0">
            <span className="sr-only">Open menu</span>
            <MoreHorizontal className="h-4 w-4" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end">
          {children}
        </DropdownMenuContent>
      </DropdownMenu>
      {dialog}
    </Dialog>
  );
}