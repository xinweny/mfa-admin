import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import { ColorSchemeScript, createTheme, MantineProvider } from '@mantine/core';

import '@mantine/core/styles.css';

const inter = Inter({ subsets: ['latin'] });

const theme = createTheme({});

export const metadata: Metadata = {
  title: 'MFA Membership',
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <head>
        <ColorSchemeScript />
      </head>
      <body className={inter.className}>
        <MantineProvider theme={theme}>
          {children}
        </MantineProvider>
      </body>
    </html>
  );
}
