import { useFormContext, useFieldArray } from 'react-hook-form';
import { XIcon, PlusIcon } from 'lucide-react';

import { MembershipType } from '../../types';

import { CreateMembershipSchema } from './schema';

import {
  Card,
  CardHeader,
  CardContent,
} from '@/components/ui/card';
import { Button } from '@/components/ui/button';

import {
  FormSection,
  FormSectionHeader,
  FormSectionContent,
} from '@/core/form/components/form-section';

import { MemberFormFields } from '@/modules/member/components/member-form-fields';


export function MembersFormSection() {
  const { control, watch } = useFormContext<CreateMembershipSchema>();
  const { fields, append, remove } = useFieldArray({
    control,
    name: 'members',
  });

  const membershipType = watch('membershipType');

  return (
    <FormSection>
      <FormSectionHeader className="flex justify-between items-center">
        <span>Members</span>
        <Button
          type="button"
          variant="link"
          className="gap-2"
          onClick={() => {
            append({
              firstName: '',
              lastName: '',
              email: '',
              phoneNumber: '',
              joinedDate: new Date(),
            });
          }}
          disabled={
            (membershipType === MembershipType.Single && fields.length >= 1)
            || (fields.length >= 4)
          }
        >
          <PlusIcon width={16} />
          <span>Add Member</span>
        </Button>
      </FormSectionHeader>
      <FormSectionContent className="flex flex-row flex-wrap">
        {
          fields.map((field, index) => (
            <Card key={field.id} className="max-w-[300px]">
              <CardHeader className="flex-row font-semibold flex items-center justify-between">
                <span>{`Member ${index + 1}`}</span>
                <button
                  className="disabled:opacity-50"
                  onClick={() => {
                    remove(index);
                  }}
                  disabled={fields.length === 1}
                >
                  <XIcon />
                </button>
              </CardHeader>
              <CardContent className="flex flex-col gap-2">
                <MemberFormFields name={`members.${index}`} />
              </CardContent>
            </Card>
          ))
        }
      </FormSectionContent>
    </FormSection>
  );
}