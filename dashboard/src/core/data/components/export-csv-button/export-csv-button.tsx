import {
  FileSpreadsheetIcon,
} from 'lucide-react';

import { downloadFile } from '@/utils/download-file';
import { convertToCsv } from '@/utils/convert-to-csv';

import { Button } from '@/components/ui/button';

interface ExportCsvButtonProps {
  csv: string[][];
  fileName: string;
}

export function ExportCsvButton({
  csv,
  fileName,
}: ExportCsvButtonProps) {
  return (
    <Button
      onClick={() => {
        const csvString = convertToCsv(csv);
    
        downloadFile({
          data: csvString,
          type: 'text/csv',
          fileName: `${Date.now()}_${fileName}.csv`,
        });
      }}
      className="flex items-center gap-2"
    >
      <FileSpreadsheetIcon />
      <span>Export to CSV</span>
    </Button>
  );
}