import { forwardRef } from 'react';

import { Input, InputProps } from '@/components/ui/input';

interface NumberInputFilterProps extends InputProps {}

export const NumberInputFilter = forwardRef<HTMLInputElement, NumberInputFilterProps>((props, ref) => {
  return (
    <Input
      type="number"
      className="w-auto"
      {...props}
      ref={ref}
    />
  );
})

NumberInputFilter.displayName = 'NumberInputFilter';