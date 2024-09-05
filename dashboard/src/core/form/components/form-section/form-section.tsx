interface FormSectionProps {
  children: React.ReactNode;
}

export function FormSection({
  children,
}: FormSectionProps) {
  return (
    <fieldset className="flex flex-col gap-2">
      {children}
    </fieldset>
  );
}