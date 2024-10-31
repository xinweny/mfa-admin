'use client';

import { GetMembershipResponse, MembershipType } from '@/modules/membership/types';

import { formatMemberNames } from '../../utils';

import {
  Accordion,
  AccordionItem,
  AccordionContent,
  AccordionTrigger,
} from '@/components/ui/accordion';

import { FormSectionHeader } from '@/core/form/components/form-section';

import { UpdateMemberForm } from './update-member-form';
import { AddMemberButton } from '../add-member-button';

interface UpdateMembersFormProps {
  members: GetMembershipResponse['members'];
  membershipId: string;
  membershipType: MembershipType;
}

export function UpdateMembersForm({
  members,
  membershipId,
  membershipType,
}: UpdateMembersFormProps) {
  return (
    <div className="flex flex-col gap-4">
      <div className="flex items-center justify-between">
        <h2 className="text-xl font-semibold">Members</h2>
        <AddMemberButton
          membershipType={membershipType}
          membershipId={membershipId}
          numMembers={members.length}
        />
      </div>
      <Accordion type="multiple" defaultValue={members.map(member => member.id)}>
        {members.map(member => (
          <AccordionItem value={member.id} key={member.id}>
            <AccordionTrigger>
              <FormSectionHeader>{formatMemberNames(members)}</FormSectionHeader>
            </AccordionTrigger>
            <AccordionContent>
              <UpdateMemberForm
                key={membershipId}
                member={member}
                membershipId={membershipId}
              />
            </AccordionContent>
          </AccordionItem>
        ))}
      </Accordion>
    </div>
  );
}