export interface data {
  id: number;
  title: string;
  description: string;
  cost: number;
  quantity: 1;
  base64String: string;
  imageName: string;
}
export interface Product {
  data: data[]
}
