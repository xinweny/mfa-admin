interface ErrorResponseParams {
  status: number;
  detail: string;
  title: string;
}

export class ErrorResponse extends Error {
  public title: string;
  public status: number;

  constructor(params: ErrorResponseParams) {
    const { title, detail, status } = params;

    super(detail);
    
    this.status = status;
    this.title = title;
  }
}