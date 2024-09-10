import { Card, CardTitle, CardDescription } from '@/components/ui/card';

interface NumberCardProps {
  value: number;
  label: string;
}

export function NumberCard({
  value,
  label
}: NumberCardProps) {


  return (
    <Card className="text-center p-3">
      <CardTitle className="text-4xl">{value}</CardTitle>
      <CardDescription>{label}</CardDescription>
    </Card>
  );
}