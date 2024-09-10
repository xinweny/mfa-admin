interface DashboardContentProps {
  children: React.ReactNode;
}

export function DashboardContent({
  children,
}: DashboardContentProps) {
  return (
    <main className="flex flex-col p-4 gap-4">
      {children}
    </main>
  );
}