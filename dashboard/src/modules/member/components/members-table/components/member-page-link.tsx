import Link from 'next/link';

interface MemberPageLinkProps {
  memberId: string;
  children: React.ReactNode;
}

export function MemberPageLink({
  memberId,
  children,
}: MemberPageLinkProps) {
  return (
    <Link href={`/dashboard/members/${memberId}`}>{children}</Link>
  );
}