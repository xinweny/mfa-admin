interface DataTableHeaderProps {
  text: string;
}

export function DataTableHeader({
  text,
}: DataTableHeaderProps) {
  return (
    <h1 className="text-3xl font-bold mb-2">{text}</h1>
  );
}