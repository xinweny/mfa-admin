import { SortOrder } from '@/types/sort-order';

export interface GetMembershipsRequest {
  yearPaid: number | null;
  query: string | null;
  sortStartDate: SortOrder | null;
}