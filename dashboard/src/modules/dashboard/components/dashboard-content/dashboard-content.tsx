interface DashboardContentProps {
  children: React.ReactNode;
}

export function DashboardContent({
  children,
}: DashboardContentProps) {
  return (
    <main className="p-4">
      {children}
    </main>
  );
}