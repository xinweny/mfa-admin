import Link from 'next/link';

interface MembersCellProps {
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
}

export function MembersCell({
  members,
}: MembersCellProps) {
  return (
    <ul className="flex-col">
      {members
        .map(member => (
          <li key={member.id} className="text-medium">
            <Link href={`/dashboard/members/${member.id}`}>
              {`${member.firstName} ${member.lastName.toUpperCase()}`}
            </Link>
          </li>
        ))}
    </ul>
  );
}