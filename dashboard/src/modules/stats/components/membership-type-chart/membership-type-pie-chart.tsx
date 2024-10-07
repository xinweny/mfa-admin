'use client';

import {
  PieChart,
  Pie,
  Cell,
  LabelList,
  Label,
} from 'recharts';

import {
  ChartContainer,
  ChartLegend,
  ChartLegendContent,
} from '@/components/ui/chart';

interface MembershipTypePieChartProps {
  counts: {
    single: number;
    family: number;
    honorary: number;
  }
}

export function MembershipTypePieChart({
  counts,
}: MembershipTypePieChartProps) {
  const { single, family, honorary } = counts;

  const totalCount = single + family + honorary;

  const data = [
    {
      label: 'single',
      value: single,
    },
    {
      label: 'family',
      value: family,
    },
    {
      label: 'honorary',
      value: honorary,
    },
  ];

  return (
    <ChartContainer config={{
      single: {
        label: 'Single',
        color: cellColors[0],
      },
      family: {
        label: 'Family',
        color: cellColors[1],
      },
      honorary: {
        label: 'Honorary',
        color: cellColors[2],
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
                      {totalCount}
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
            dataKey="value"
            position="outside"
            formatter={(v: number) => `${(v / totalCount * 100).toFixed(1)}%`}
          />
        </Pie>
        <ChartLegend content={<ChartLegendContent nameKey="label" />} />
      </PieChart>
    </ChartContainer>
  );
}

const cellColors = ['#eab308', '#22c55e', '#3b82f6'];