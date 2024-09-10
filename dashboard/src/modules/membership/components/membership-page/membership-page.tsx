import { DashboardContent } from '@/modules/dashboard/components/dashboard-content';

interface MembershipPageProps {
  params: {
    membershipId: string;
  };
}

export async function MembershipPage({
  params: { membershipId },
}: MembershipPageProps) {
  return (
    <DashboardContent>
      Membership {membershipId}
    </DashboardContent>
  );
}