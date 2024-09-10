import { Province } from './province';

export interface Address {
  line1: string;
  line2: string | null;
  city: string;
  province: Province;
  postalCode: string;
}