import { ApiResponseMetadata } from './api-response-metadata';

export interface ApiResponse<T> {
  metadata: ApiResponseMetadata | null;
  data: T | null;
  message: string | null;
}