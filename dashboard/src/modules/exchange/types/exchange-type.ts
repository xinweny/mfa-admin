export enum ExchangeType {
  Host = 1,
  Delegate = 2,
}

export const exchangeTypeLabels: Record<ExchangeType, string> = {
  [ExchangeType.Host]: 'Host',
  [ExchangeType.Delegate]: 'Delegate',
};