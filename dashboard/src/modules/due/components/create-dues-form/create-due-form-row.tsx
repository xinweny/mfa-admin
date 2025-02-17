'use client';

import { UseFieldArrayRemove } from 'react-hook-form';
import { XIcon } from 'lucide-react';
import { format } from 'date-fns';

import { paymentMethodOptions } from '../../types';

import { MFA_FOUNDING_YEAR } from '@/core/constants';

import { formatHtmlDateString } from '@/utils';

import { TableRow, TableCell } from '@/components/ui/table';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import { TableCellField } from '@/components/form/table-cell-field';
import { FormInputSelect } from '@/components/form/form-input-select';

import { MembershipSearchInput } from './membership-search-input';
import { AmountPaidDisplay } from './amount-paid-display';

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
        name={`${prefix}.year`}
        render={(field) => (
          <Input
            type="number"
            value={field.value}
            onChange={field.onChange}
            className="w-auto"
            min={MFA_FOUNDING_YEAR}
            max={new Date().getFullYear() + 1}
          />
        )}
      />
      <TableCellField
        name={`${prefix}.membership`}
        render={(field) => (
          <MembershipSearchInput
            index={index}
            value={field.value}
            onSelect={field.onChange}
          />
        )}
      />
      <TableCell>
        <AmountPaidDisplay index={index} />
      </TableCell>
      <TableCellField
        name={`${prefix}.paymentMethod`}
        render={(field) => (
          <FormInputSelect
            value={field.value?.toString()}
            options={paymentMethodOptions}
            onChange={value => {
              field.onChange(+value);
            }}
            placeholder="Select method"
          />
        )}
      />
      <TableCellField
        name={`${prefix}.paymentDate`}
        render={(field) => (
          <Input
            type="date"
            value={formatHtmlDateString(field.value)}
            onChange={field.onChange}
            className="w-auto"
          />
        )}
      />
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