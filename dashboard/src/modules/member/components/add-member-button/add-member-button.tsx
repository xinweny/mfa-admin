import { UserPlusIcon } from 'lucide-react';

import { MembershipType } from '@/modules/membership/types';

import { Button } from '@/components/ui/button';
import {
  TooltipProvider,
  TooltipContent,
  TooltipTrigger,
  Tooltip,
} from '@/components/ui/tooltip';
import {
  Dialog,
  DialogContent,
  DialogTrigger,
} from '@/components/ui/dialog';

import { AddMemberForm } from '../add-member-form';

interface AddMemberButtonProps {
  membershipId: string;
  membershipType: MembershipType;
  numMembers: number;
}

export function AddMemberButton({
  membershipId,
  membershipType,
  numMembers,
}: AddMemberButtonProps) {
  const isSingleMembership = membershipType === MembershipType.Single;
  const hasMaxMembers = numMembers === 4;

  const isDisabled = isSingleMembership || hasMaxMembers;

  const button = (
    <DialogTrigger asChild>
      <Button
        variant="secondary"
        className="gap-2"
        disabled={isDisabled}
      >
        <UserPlusIcon />
        <span>Add Member</span>
      </Button>
    </DialogTrigger>
  );

  return (
    <Dialog>
      {isDisabled
        ? (
          <TooltipProvider>
            <Tooltip>
              <TooltipTrigger asChild>
                <span tabIndex={0}>
                  {button}
                </span>
              </TooltipTrigger>
              <TooltipContent>
                {isSingleMembership && (
                  <span>Single memberships can only have one member.</span>
                )}
                {hasMaxMembers && (
                  <span>Maximum of 4 members reached.</span>
                )}
              </TooltipContent>
            </Tooltip>
          </TooltipProvider>
        )
        : button
      }
      <DialogContent>
        <AddMemberForm membershipId={membershipId} />
      </DialogContent>
    </Dialog>
  );
}