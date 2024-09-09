import toast from 'react-hot-toast';

import { ErrorResponse } from '../types';

export const handleError = (err: unknown) => {
  if (err instanceof ErrorResponse) {
    toast.error(err.message);
  } else {
    toast.error('Something went wrong.');
  }
}