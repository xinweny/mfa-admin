'use client';

import { cn } from '@/lib/cn';

import {
  Tabs,
  TabsList,
  TabsContent,
  TabsTrigger,
} from '@/components/ui/tabs';

interface DashboardTabsProps {
  defaultValue: string;
  tabs: {
    value: string;
    label: string;
    component: React.ReactNode;
  }[];
  classNames?: {
    tabsList?: string;
    tabsContent?: string;
    tabsTrigger?: string;
  };
}

export function DashboardTabs({
  defaultValue,
  tabs,
  classNames,
}: DashboardTabsProps) {
  return (
    <Tabs defaultValue={defaultValue}>
      <TabsList className={cn('w-full flex-wrap h-auto mb-4', classNames?.tabsList)}>
        {tabs.map(({ value, label }) => (
          <TabsTrigger
            key={value}
            className={cn('flex-grow', classNames?.tabsTrigger)}
            value={value}
          >
            {label}
          </TabsTrigger>
        ))}
      </TabsList>
      {tabs.map(({ value, component }) => (
        <TabsContent
          key={value}
          value={value}
          className={cn('border rounded-lg p-8', classNames?.tabsContent)}
        >
          {component}
        </TabsContent>
      ))}
    </Tabs>
  );
}