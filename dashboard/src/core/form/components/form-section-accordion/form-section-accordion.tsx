import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from '@/components/ui/accordion';

interface FormSectionAccordionProps {
  name: string;
  label: string;
  children: React.ReactNode;
}

export function FormSectionAccordion({
  name,
  label,
  children,
}: FormSectionAccordionProps) {
  return (
    <Accordion type="single" defaultValue={name} collapsible>
      <AccordionItem value={name}>
        <AccordionTrigger>
          {label}
        </AccordionTrigger>
        <AccordionContent>
          {children}
        </AccordionContent>
      </AccordionItem>
    </Accordion>
  );
}