import Link from 'next/link';

interface MemberCellProps {
  member: {
    id: string;
    firstName: string;
    lastName: string;
  }
}

export function MemberCell({
  member: {
    id,
    firstName,
    lastName,
  },
}: MemberCellProps) {
  return (
    <Link href={`/dashboard/members/${id}`}>
      {`${firstName} ${lastName.toUpperCase()}`}
    </Link>
  );
}