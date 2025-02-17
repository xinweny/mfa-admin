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
            {`${member.firstName} ${member.lastName.toUpperCase()}`}
          </li>
        ))}
    </ul>
  );
}