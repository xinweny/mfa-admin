'use client';

import { useTheme } from 'next-themes';
import { MoonIcon, SunIcon } from 'lucide-react';

import { Switch } from '@/components/ui/switch';

export function ThemeSwitch() {
  const { theme, setTheme } = useTheme();

  return (
    <Switch
      value={theme}
      onCheckedChange={(checked) => {
        setTheme(checked ? 'light' : 'dark');
      }}
    >
      {theme == 'light'
        ? <SunIcon size={12} />
        : <MoonIcon size={12} />
      }
    </Switch>
  );
}