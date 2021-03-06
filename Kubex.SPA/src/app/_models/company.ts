import { Post, Contact, Address } from '.';

export class Company {
    id: number;
    name: string;
    logoUrl: string;
    customerNumber: string;
    address: Address;
    contacts: Array<Contact>;
    posts: Array<Post>;
}
