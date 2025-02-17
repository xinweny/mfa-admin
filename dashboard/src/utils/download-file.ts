export const downloadFile = (params: {
  data: string;
  type: string;
  fileName: string;
}) => {
  const { data, type, fileName } = params;

  // Convert string representation to blob for download
  const blob = new Blob([data], { type });

  const url = URL.createObjectURL(blob);

  // Create invisible <a> element containing download file and click
  const link = document.createElement('a');
  link.href = url;
  link.download = fileName;

  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
};