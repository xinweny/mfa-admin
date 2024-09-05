interface FormSectionHeaderProps {
  title: string;
}

export function FormSectionHeader({
  title,
}: FormSectionHeaderProps) {
  return (
    <h3 className="text-xl font-semibold">{title}</h3>
  );
}