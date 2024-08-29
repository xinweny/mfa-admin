import { Address, Province } from '../../types';
import { provinceLabels } from '../../constants';

interface AddressDisplayProps {
  address: Address;
}

export function AddressDisplay({
  address: {
    line1,
    line2,
    city,
    province,
    postalCode,
  },
}: AddressDisplayProps) {
  return (
    <span className="flex flex-col">
      <span>{line1}</span>
      <span>{line2}</span>
      <span>{city}</span>
      <span>{`${provinceLabels[province]} ${postalCode}`}</span>
    </span>
  );
}