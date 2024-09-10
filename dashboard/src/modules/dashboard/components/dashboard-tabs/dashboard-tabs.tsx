'use client';

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
}

export function DashboardTabs({
  defaultValue,
  tabs,
}: DashboardTabsProps) {
  return (
    <Tabs defaultValue={defaultValue}>
      <TabsList className="w-full flex-wrap h-auto">
        {tabs.map(({ value, label }) => (
          <TabsTrigger
            key={value}
            className="flex-grow"
            value={value}
          >
            {label}
          </TabsTrigger>
        ))}
      </TabsList>
      {tabs.map(({ value, component }) => (
        <TabsContent key={value} value={value}>
          {component}
        </TabsContent>
      ))}
    </Tabs>
  );
}