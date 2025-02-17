export const convertToCsv = (table: string[][]) => {
  return table
    .map(row => row.map(cell => `"${cell}"`).join(',')) // Enclose data in ""  to allow for commas
    .join('\n');
};