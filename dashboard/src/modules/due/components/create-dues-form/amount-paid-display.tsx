import { useFormContext } from 'react-hook-form';
import { CreateDuesSchema } from './schema';

export function AmountPaidDisplay() {
  const { watch } = useFormContext<CreateDuesSchema>();

  return (
    <span className="font-semibold">{`$${0}.00`}</span>
  );
}