'use client';

import { useGetMembersByDateUrlParams } from '../../state';

import { DateRangeFilter } from '@/core/data/components/date-range-filter';

export function JoinedDateRangeSelect() {
  const [{ joinedFrom, joinedTo }, setJoinedDate] = useGetMembersByDateUrlParams();

  return (
    <DateRangeFilter
      date={{
        from: joinedFrom,
        to: joinedTo,
      }}
      onChange={d => {
        if (!d || !d.from || !d.to) return;

        setJoinedDate({
          joinedFrom: d.from,
          joinedTo: d.to,
        });
      }}
    />
  );
}