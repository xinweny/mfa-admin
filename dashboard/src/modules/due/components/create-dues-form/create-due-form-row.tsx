'use client';

import { UseFieldArrayRemove } from 'react-hook-form';
import { XIcon } from 'lucide-react';

import { PaymentMethod, paymentMethodLabels } from '../../types';

import { TableRow, TableCell } from '@/components/ui/table';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import { TableCellField } from '@/core/form/components/table-cell-field';
import { FormInputDate } from '@/core/form/components/form-input-date';
import { FormInputSelect } from '@/core/form/components/form-input-select';

interface CreateDueFormRowProps {
  index: number;
  remove: UseFieldArrayRemove;
}

export function CreateDueFormRow({
  index,
  remove,
}: CreateDueFormRowProps) {
  const prefix = `dues.${index}`;

  return (
    <TableRow>
      <TableCell>{index + 1}</TableCell>
      <TableCellField
        name={`${prefix}.membershipId`}
        render={(field) => (
          <></>
        )}
      />
      <TableCellField
        name={`${prefix}.year`}
        render={(field) => (
          <Input
            type="number"
            value={field.value}
            onChange={field.onChange}
          />
        )}
      />
      <TableCellField
        name={`${prefix}.paymentMethod`}
        render={(field) => (
          <FormInputSelect
            value={field.value?.toString()}
            options={paymentMethodOptions}
            onChange={value => {
              field.onChange(+value);
            }}
          />
        )}
      />
      <TableCellField
        name={`${prefix}.paymentDate`}
        render={(field) => (
          <FormInputDate
            value={field.value}
            onChange={field.onChange}
          />
        )}
      />
      <TableCell>
        <span className="font-semibold">{`$${0}.00`}</span>
      </TableCell>
      <TableCell>
        <Button
          type="button"
          variant="ghost"
          onClick={() => {
            remove(index);
          }}
        >
          <XIcon width={16} />
        </Button>
      </TableCell>
    </TableRow>
  );
}

const paymentMethodOptions = [
  {
    value: PaymentMethod.Cash,
    label: paymentMethodLabels[PaymentMethod.Cash],
  },
  {
    value: PaymentMethod.EFT,
    label: paymentMethodLabels[PaymentMethod.EFT],
  },
  {
    value: PaymentMethod.Cheque,
    label: paymentMethodLabels[PaymentMethod.Cheque],
  },
];