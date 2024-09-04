interface DashboardContentHeaderProps {
  children: React.ReactNode;
}

export function DashboardContentHeader({
  children,
}: DashboardContentHeaderProps) {
  return (
    <div className="flex items-center justify-between mb-4">
      {children}
    </div>
  );
}

interface DashboardContentHeadingProps {
  text: string;
}

export function DashboardContentHeading({
  text,
}: DashboardContentHeadingProps) {
  return (
    <h1 className="text-3xl font-bold mb-2">{text}</h1>
  );
}