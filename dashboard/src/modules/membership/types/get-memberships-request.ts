import { SortOrder } from '@/types/sort-order';

export interface GetMembershipsRequest {
  year?: string;
  query?: string;
  sortStartDate?: SortOrder;
}