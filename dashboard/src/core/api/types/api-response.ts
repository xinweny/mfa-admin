import { ApiResponseMetadata } from './api-response-metadata';

export type ApiResponse<T> = {
  metadata: ApiResponseMetadata | null;
  data: T | null;
  message: string | null;
}