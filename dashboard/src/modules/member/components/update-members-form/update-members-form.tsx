'use client';

import {
  Accordion,
  AccordionItem,
  AccordionContent,
  AccordionTrigger,
} from '@/components/ui/accordion';

import { GetMembershipResponse } from '@/modules/membership/types';
import { UpdateMemberForm } from './update-member-form';
import { FormSectionHeader } from '@/core/form/components/form-section';

interface UpdateMembersFormProps {
  members: GetMembershipResponse['members'];
  membershipId: string;
}

export function UpdateMembersForm({
  members,
  membershipId,
}: UpdateMembersFormProps) {
  return (
    <div className="flex flex-col gap-4">
      <h2 className="text-xl font-semibold">Members</h2>
      <Accordion type="multiple" defaultValue={members.map(member => member.id)}>
        {members.map(member => (
          <AccordionItem value={member.id} key={member.id}>
            <AccordionTrigger>
              <FormSectionHeader>{`${member.firstName} ${member.lastName}`}</FormSectionHeader>
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