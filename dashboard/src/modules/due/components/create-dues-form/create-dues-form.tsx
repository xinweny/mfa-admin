'use client';

import { useForm, useFieldArray } from 'react-hook-form';
import { ListPlusIcon } from 'lucide-react';

import { CreateDuesSchema, createDuesSchemaResolver } from './schema';

import {
  Table,
  TableHeader,
  TableBody,
  TableRow,
  TableHead,
} from '@/components/ui/table';
import { Button } from '@/components/ui/button';

import { DashboardForm } from '@/core/form/components/dashboard-form';
import { FormSection } from '@/core/form/components/form-section';

import { CreateDueFormRow } from './create-due-form-row';

export function CreateDuesForm() {
  const form = useForm<CreateDuesSchema>({
    defaultValues: {
      dues: [initialFields],
    },
    resolver: createDuesSchemaResolver,
  });
  const { fields, append, remove } = useFieldArray<CreateDuesSchema>({
    control: form.control,
    name: 'dues',
  });

  const onSubmit = async () => {
    form.reset({
      dues: [initialFields],
    });
  };

  return (
    <DashboardForm form={form} onSubmit={onSubmit}>
      <FormSection>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead></TableHead>
              <TableHead>Year</TableHead>
              <TableHead>Membership</TableHead>
              <TableHead>Method</TableHead>
              <TableHead>Payment Date</TableHead>
              <TableHead>Amount</TableHead>
              <TableHead></TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {fields.map((field, index) => (
              <CreateDueFormRow
                key={field.id}
                index={index}
                remove={remove}
              />
            ))}
          </TableBody>
        </Table>
        <Button
          type="button"
          variant="secondary"
          className="gap-2"
          onClick={() => {
            append(initialFields);
          }}
        >
          <ListPlusIcon />
          <span>Add Row</span>
        </Button>
      </FormSection>
    </DashboardForm>
  );
}

const initialFields = {
  membership: undefined as any,
  year: undefined as any,
  amountPaid: undefined as any,
  paymentMethod: undefined as any,
  paymentDate: undefined as any,
};