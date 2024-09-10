interface DashboardContentTitleProps {
  title: string;
  description?: string;
}

export function DashboardContentTitle({
  title,
  description,
}: DashboardContentTitleProps) {
  return (
    <div className="flex flex-col">
      <h1 className="text-3xl font-bold">{title}</h1>
      {description && (
        <h2 className="text-sm text-secondary-foreground">{description}</h2>
      )}
    </div>
    
  );
}