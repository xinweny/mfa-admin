import { format } from 'date-fns';

export const formatHtmlDateString = (date?: Date) => {
  return date ? format(date, 'yyyy-LL-dd') : undefined
};