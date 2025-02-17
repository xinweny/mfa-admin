import { Address, provinceLabels } from '../types';

export const formatAddressString = (address: Address) => {
  return `${address.line1}, ${address.line2 ? `${address.line2}, ` : ''}, ${address.city}, ${provinceLabels[address.province]} ${address.postalCode}`
}