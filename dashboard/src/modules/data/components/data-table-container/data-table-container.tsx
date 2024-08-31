interface DataTableContainerProps {
  children: React.ReactNode;
}

export function DataTableContainer({
  children,
}: DataTableContainerProps) {
  return (
    <div className="flex flex-col gap-2">
      {children}
    </div>
  );
}