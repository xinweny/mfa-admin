interface MembersCellProps {
  id: string;
  members: {
    id: string;
    firstName: string;
    lastName: string;
  }[];
}

export function MembersCell({
  id,
  members,
}: MembersCellProps) {
  return (
    <ul>
      {members.map(m => (
        <li key={m.id}>{`${m.firstName} ${m.lastName.toUpperCase()}`}</li>
      ))}
    </ul>
  );
}