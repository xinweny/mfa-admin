interface DataTableMenuProps {
  children: React.ReactNode;
}

export function DataTableMenu({
  children,
}: DataTableMenuProps) {
  return (
    <div className="flex gap-2 justify-between items-end flex-wrap">
      {children}
    </div>
  );
}