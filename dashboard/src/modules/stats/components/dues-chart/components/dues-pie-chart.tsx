'use client';

import {
  PieChart,
  Pie,
  Cell,
  LabelList,
  Label,
  ResponsiveContainer,
} from 'recharts';

import {
  ChartContainer,
  ChartLegend,
  ChartLegendContent,
} from '@/components/ui/chart';

interface DuesPieChartProps {
  amountOwed: number;
  amountPaid: number;
}

export function DuesPieChart({
  amountOwed,
  amountPaid,
}: DuesPieChartProps) {
  const data = [
    {
      label: 'unpaid',
      value: amountOwed - amountPaid,
    },
    {
      label: 'paid',
      value: amountPaid,
    },
  ];

  return (
    <ChartContainer config={{
      unpaid: {
        label: 'Unpaid',
        color: cellColors[0],
      },
      paid: {
        label: 'Paid',
        color: cellColors[1],
      },
    }}>
      <PieChart>
        <Pie
          dataKey="value"
          data={data}
          innerRadius={60}
          outerRadius={80}
          isAnimationActive={false}
        >
          {data.map((_, index) => (
            <Cell key={`cell-${index}`} fill={cellColors[index]} />
          ))}
          <Label
            content={({ viewBox }) => {
              if (viewBox && 'cx' in viewBox &&'cy' in viewBox) {
                return (
                  <text
                    x={viewBox.cx}
                    y={viewBox.cy}
                    textAnchor="middle"
                    dominantBaseline="middle"
                  >
                    <tspan
                      x={viewBox.cx}
                      y={viewBox.cy}
                      className="fill-foreground text-3xl font-bold"
                    >
                      {`$${amountOwed.toLocaleString()}`}
                    </tspan>
                    <tspan
                      x={viewBox.cx}
                      y={(viewBox.cy || 0) + 24}
                      className="fill-muted-foreground"
                    >
                      Total
                    </tspan>
                  </text>
                )
              }
            }}
          />
          <LabelList
            formatter={(v: number) => `$${v.toLocaleString()}`}
            dataKey="value"
            position="outside"
          />
        </Pie>
        <ChartLegend content={<ChartLegendContent nameKey="label" />} />
      </PieChart>
    </ChartContainer>
  );
}

const cellColors = ['#ef4444', '#3b82f6'];