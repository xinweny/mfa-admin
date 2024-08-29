interface DataTableHeaderProps {
  text: string;
}

export function DataTableHeader({
  text,
}: DataTableHeaderProps) {
  return (
    <h1 className="text-3xl font-bold mb-4">{text}</h1>
  );
}