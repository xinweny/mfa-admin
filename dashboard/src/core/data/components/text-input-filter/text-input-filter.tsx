import { forwardRef } from 'react';

import { Input, InputProps } from '@/components/ui/input';

interface TextInputFilterProps extends InputProps {};

export const TextInputFilter = forwardRef<HTMLInputElement, TextInputFilterProps>((props, ref) => {
  return (
    <Input {...props} ref={ref} />
  );
})

TextInputFilter.displayName = 'TextInputFilter';