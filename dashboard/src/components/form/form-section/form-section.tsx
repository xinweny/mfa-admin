interface FormSectionProps {
  children: React.ReactNode;
}

export function FormSection({
  children,
}: FormSectionProps) {
  return (
    <section className="flex flex-col gap-2">
      {children}
    </section>
  );
}