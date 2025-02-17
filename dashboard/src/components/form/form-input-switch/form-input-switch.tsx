import { FormLabel, FormDescription } from '@/components/ui/form';
import { Switch } from '@/components/ui/switch';

interface FormInputSwitchProps {
  value: boolean;
  onCheckedChange: (value: boolean) => void;
  label: string;
  description?: string;
}

export function FormInputSwitch({
  value,
  onCheckedChange,
  label,
  description,
}: FormInputSwitchProps) {
  return (
    <div className="flex flex-row items-center justify-between rounded-lg border p-4">
      <div className="space-y-0.5">
        <FormLabel className="text-base">
          {label}
        </FormLabel>
        {description && (
          <FormDescription>
            {description}
          </FormDescription>
        )}
      </div>
      <Switch
        checked={value}
        onCheckedChange={onCheckedChange}
      />
    </div>
  );
}