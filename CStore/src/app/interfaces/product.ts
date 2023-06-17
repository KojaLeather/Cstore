export interface data {
  id: number;
  title: string;
  description: string;
  cost: number;
  quantity: number;
  base64String: string;
  imageName: string;
}
export interface Product {
  data: data[]
}
