'use client';

import { useForm, useFieldArray } from 'react-hook-form';
import { ListPlusIcon } from 'lucide-react';

import { CreateDuesSchema, createDuesSchemaResolver } from './schema';

import { handleError } from '@/core/api/utils';

import {
  Table,
  TableHeader,
  TableBody,
  TableRow,
  TableHead,
} from '@/components/ui/table';
import { Button } from '@/components/ui/button';

import { DashboardForm } from '@/components/form/dashboard-form';
import { FormSection } from '@/components/form/form-section';
import { CreateDueFormRow } from './create-due-form-row';

import { createDues } from '../../actions';

export function CreateDuesForm() {
  const form = useForm<CreateDuesSchema>({
    defaultValues: {
      dues: [],
    },
    resolver: createDuesSchemaResolver,
  });
  const { fields, append, remove } = useFieldArray<CreateDuesSchema>({
    control: form.control,
    name: 'dues',
  });

  const onSubmit = async (data: CreateDuesSchema) => {
    try {
      await createDues({
        dues: data.dues.map(d => ({
          membershipId: d.membership.id,
          year: d.year,
          amountPaid: d.amountPaid,
          paymentMethod: d.paymentMethod,
          paymentDate: d.paymentDate,
        })),
      });

      form.reset({
        dues: [],
      });
    } catch (err) {
      handleError(err);
    }
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
              <TableHead>Amount</TableHead>
              <TableHead>Payment Method</TableHead>
              <TableHead>Payment Date</TableHead>
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
            append({
              membership: undefined as any,
              year: undefined as any,
              amountPaid: undefined as any,
              paymentMethod: undefined as any,
              paymentDate: undefined as any,
            });
          }}
        >
          <ListPlusIcon />
          <span>Add Row</span>
        </Button>
      </FormSection>
    </DashboardForm>
  );
}