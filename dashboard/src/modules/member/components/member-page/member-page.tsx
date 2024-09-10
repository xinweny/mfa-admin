import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

interface MemberPageProps {
  params: {
    memberId: string;
  };
}

export async function MemberPage({
  params: { memberId },
}: MemberPageProps) {
  return (
    <DashboardContent>
      Membership {memberId}
    </DashboardContent>
  );
}