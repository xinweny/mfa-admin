interface DashboardFormTitleProps {
  title: string;
}

export function DashboardFormTitle({
  title,
}: DashboardFormTitleProps) {
  return (
    <h1 className="text-2xl font-bold">{title}</h1>
  );
}