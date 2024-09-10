import { Card, CardTitle, CardDescription } from '@/components/ui/card';

interface NumberCardProps {
  value: string;
  label: string;
}

export function NumberCard({
  value,
  label
}: NumberCardProps) {
  return (
    <Card className="flex-grow text-center p-4 bg-secondary">
      <CardTitle className="text-4xl">{value}</CardTitle>
      <CardDescription>{label}</CardDescription>
    </Card>
  );
}